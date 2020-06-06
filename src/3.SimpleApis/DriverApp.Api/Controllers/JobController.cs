using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DriverApp.Api.Models;
using DriverApp.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DriverApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private static Dictionary<Guid, Job> _data = new Dictionary<Guid, Job>();

        [HttpGet]
        public IActionResult GetJobs()
        {
            return Ok(_data.Values);
        }

        [HttpPost]
        public IActionResult AddJob(AddJobRequest request)
        {
            if (new Random().Next(0, 2) % 2 == 0)
            {
                return BadRequest();
            } else {
                var newJob = new Job
                {
                    Id = Guid.NewGuid(),
                    PickupPostcode = request.PickupPostcode,
                    DestinationPostcode = request.DestinationPostcode,
                    Cancelled = false
                };

                _data.Add(newJob.Id, newJob);

                return StatusCode((int)HttpStatusCode.Created, new
                {
                    Id = newJob.Id
                });
            }
        }

        [HttpDelete]
        [Route("{jobId}")]
        public IActionResult CancelJob(Guid jobId)
        {
            if (!_data.ContainsKey(jobId))
            {
                return NotFound();
            }

            _data[jobId].Cancelled = true;

            return Ok();
        }
    }
}