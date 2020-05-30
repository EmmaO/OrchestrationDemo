using CustomerBooking.Orchestration.CreateBooking;
using CustomerBooking.Orchestration.CreateBooking.StageHandlers;
using Microsoft.Extensions.DependencyInjection;
using Orchestration;
using OrchestrationDemo.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerBooking.Orchestration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrchestration(this IServiceCollection services)
        {
            services.AddOrchestrationPackage();
            services.AddCreateBookingOrchestrator();
        }

        public static void AddCreateBookingOrchestrator(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateBookingOrchestrationRequest>, CreateBookingOrchestrator>();

            services.AddScoped<IAddBookingStageHandler, AddBookingStageHandler>();
            services.AddScoped<IAddDriverJobStageHandler, AddDriverJobStageHandler>();
            services.AddScoped<ICalculateDistanceStageHandler, CalculateDistanceStageHandler>();
            services.AddScoped<IChargeCustomerStageHandler, ChargeCustomerStageHandler>();
        }
    }
}
