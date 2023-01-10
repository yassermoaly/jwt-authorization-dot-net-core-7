using Microsoft.Extensions.DependencyInjection;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace DataAccessLayer
{
    public static class RegisterDI
    {
        public static void RegisterServiceLayer(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<ITourService, TourService>();
            serviceProvider.AddScoped<IUserService, UserService>();
            serviceProvider.AddSingleton<ITokenService, TokenService>();
        }
    }
}
