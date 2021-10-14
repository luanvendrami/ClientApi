using Domain.Interfaces.ClienteInterface.Repositorio;
using Domain.Interfaces.ClienteInterface.Service;
using Infra.Data.Context;
using Infra.Data.Repository.ClienteRepositorio;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCuting.IoC
{
    public class ConfigureServicesInjection
    {
        public static void AddInjectionContext(IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
        }

        public static void AddInjectionRepositorio(IServiceCollection services)
        {
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        }

        public static void AddInjectionService(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }
    }
}
