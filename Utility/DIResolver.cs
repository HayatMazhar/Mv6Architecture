using Core.IRepository;
using Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace Utility
{
    public  class DiResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IEmployeeService, EmployeeServices>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
