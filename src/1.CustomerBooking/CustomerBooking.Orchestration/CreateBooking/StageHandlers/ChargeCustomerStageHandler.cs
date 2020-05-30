using CustomerBooking.Service.ExternalClients.Payment;
using CustomerBooking.Service.ExternalClients.Payment.Requests;
using Orchestration;
using RequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerBooking.Orchestration.CreateBooking.StageHandlers
{
    public class ChargeCustomerStageHandler : IChargeCustomerStageHandler
    {
        private readonly IPaymentClient _paymentClient;

        public ChargeCustomerStageHandler(IPaymentClient paymentClient)
        {
            _paymentClient = paymentClient;
        }

        public async Task<StageHandlerResponse> ChargeCustomer(ChargeRequest request)
        {
            var res = await _paymentClient.ChargeCustomer(request);

            if (!res.StatusCode.IsSuccessStatusCode())
            {
                throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
            }

            return new StageHandlerResponse(async () =>
            {
                var compensationRes = await _paymentClient.ChargeCustomer(new ChargeRequest
                {
                    CustomerId = request.CustomerId,
                    Amount = request.Amount * -1
                });

                if (!compensationRes.StatusCode.IsSuccessStatusCode())
                {
                    throw new OrchestrationException(res.StatusCode, res.ErrorResponse);
                }
            });
        }
    }
}
