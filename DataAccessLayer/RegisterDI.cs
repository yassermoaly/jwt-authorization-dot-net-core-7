using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccessLayer
{
    public static class RegisterDI
    {
        public static void RegisterDataAccessLayer(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<ITourRepository, TourRepository>();
        }
    }
}
