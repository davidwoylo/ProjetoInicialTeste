using Data.Context;
using Data.Repository;
using Domain.Interfaces.Notificacoes;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Notificacoes;
using Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<TesteContext>();

            //Injecão de dependencia de Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Injecão de dependencia de Notificação
            services.AddScoped<IGerenciadorNotificacoes, GerenciadorNotificacoes>();

            //Injecão de dependencia de Services
            services.AddScoped<IProdutoService, ProdutoService>();


            return services;
        }
    }
}