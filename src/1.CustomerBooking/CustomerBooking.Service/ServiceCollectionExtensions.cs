using CustomerBooking.Service.Services.BookTaxi;
using CustomerBooking.Service.Services.CancelBooking;
using CustomerBooking.Service.Services.CreateBooking;
using CustomerBooking.Service.Services.GetBookingsByCustomer;
using Microsoft.Extensions.DependencyInjection;
using OrchestrationDemo.Handlers;

namespace CustomerBooking.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomerBookingServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateBookingRequest, CreateBookingResponse>, CreateBookingHandler>();
            services.AddScoped<IRequestHandler<CancelBookingRequest>, CancelBookingHandler>();
            services.AddScoped<IRequestHandler<GetBookingsByCustomerRequest, GetBookingsByCustomerResponse>, GetBookingsByCustomerHandler>();
        }
    }
}
