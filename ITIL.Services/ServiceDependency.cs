using ITIL.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIL.Services
{
    public static class ServiceDependency
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();
            services.AddScoped<IPersonServices, PersonServices>();
            services.AddScoped<IPersonDepartmentServices, PersonDepartmentServices>();
        }
    }
}
