using System;
using System.Threading.Tasks;

namespace Orchestration
{
    public class StageHandlerResponse
    {
        public Func<Task> CompensationTransaction{ get; set; }

        public StageHandlerResponse(Func<Task> compensationTransaction)
        {
            CompensationTransaction = compensationTransaction;
        }
    }

    public class StageHandlerResponse<T> : StageHandlerResponse
    {
        public T Response { get; set; }

        public StageHandlerResponse(T response, Func<Task> compensationTransaction) : base(compensationTransaction)
        {
            Response = response;
        }
    }
}
