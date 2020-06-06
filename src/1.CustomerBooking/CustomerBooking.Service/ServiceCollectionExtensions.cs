using CustomerBooking.Service.ExternalClients.CostCalculation;
using CustomerBooking.Service.ExternalClients.DriverApp;
using CustomerBooking.Service.ExternalClients.Payment;
using CustomerBooking.Service.Services.CancelBooking;
using CustomerBooking.Service.Services.CreateBooking;
using CustomerBooking.Service.Services.GetBookingsByCustomer;
using Microsoft.Extensions.DependencyInjection;
using RequestHandlers;

namespace CustomerBooking.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomerBookingServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICostCalculationClient, CostCalculationClient>();
            services.AddHttpClient<IDriverAppClient, DriverAppClient>();
            services.AddHttpClient<IPaymentClient, PaymentClient>();

            services.AddScoped<IRequestHandler<CreateBookingRequest, CreateBookingResponse>, CreateBookingHandler>();
            services.AddScoped<IRequestHandler<CancelBookingRequest>, CancelBookingHandler>();
            services.AddScoped<IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse>, GetBookingsByCustomerHandler>();
        }
    }
}
