using Dene.Business.Abstract;
using Dene.Business.Concrete;
using Dene.Data.Abstract;
using Dene.Data.Concrete.Ef;

namespace Dene.Api.Extensions
{
    public static class DependencyInjectionServiceExtensions
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            // .AddFluentValidation

            //Services
            
            services.AddScoped<IPatientService, PatientService>();

            ////Repository
            services.AddScoped<IPatientRepository, EfPatientRepository>();
            return services;
        }
    }

    
}

    

