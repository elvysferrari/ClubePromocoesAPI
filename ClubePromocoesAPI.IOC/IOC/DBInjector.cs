using ClubePromocoesAPI.Domain.Interfaces;
using ClubePromocoesAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ClubePromocoesAPI.IOC.IOC
{
    public static class DBInjector
    {
        public static void AddDBInjector(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUsuario, UsuarioRepository>();
            services.AddScoped<IPromocao, PromocaoRepository>();
            services.AddScoped<ILoja, LojaRepository>();
        }
    }
}
