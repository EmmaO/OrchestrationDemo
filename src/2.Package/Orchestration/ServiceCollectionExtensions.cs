using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrchestrationPackage(this IServiceCollection services)
        {
            services.AddScoped<ICompensationContext, CompensationContext>();
        }
    }
}
