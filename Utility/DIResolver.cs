using Core.IRepository;
using Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;

namespace EmployeeForm.Utility
{
    public  class DiResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services
            services.AddScoped<IEmployeeService, EmployeeServices>();

            #endregion

            #region Repository
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            #endregion
        }
    }
}
