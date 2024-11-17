using ITIL.Services.Contract;
using ITIL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITIL.Infrastructure
{
    public static class InfrastructureServices
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            //services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));





        }
    }
}
