using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using App.API;



namespace App.API
{
    public static class Extensiones
    {
        public static IServiceCollection AddValidationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(App.Validators.CreatePersonDTOValidator).Assembly);
            return services;

        }
    }
}
