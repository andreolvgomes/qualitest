using Microsoft.Extensions.DependencyInjection;
using Infra.Repositories;
using System.Data;
using Npgsql;

namespace Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            DotNetEnv.Env.TraversePath().Load();

            //services.AddScoped<IProjetosRepository, ProjetosRepository>();
            //services.AddScoped<ICasosNosRepository, CasosNosRepository>();
            //services.AddScoped<ICasosTesteRepository, CasosTesteRepository>();
            //services.AddScoped<IPassosTesteRepository, PassosTesteRepository>();

            services.AddScoped(
                typeof(IRepositoryBase<>),
                typeof(RepositoryBase<>)
            );

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            services.AddScoped<IDbConnection>(s => new NpgsqlConnection(connectionString));

            return services;
        }
    }
}