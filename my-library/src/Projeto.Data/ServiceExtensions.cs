using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Data.Context;
using Projeto.Data.Repositories;
using Projeto.Domain.Interfaces;

namespace Projeto.Data;

public static class ServiceExtensions
{
    public static void ConfigureDataApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LivroDb");
        services.AddDbContext<ContextoBd>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILivroRepository, LivroRepository>();
        services.AddScoped<IAssuntoRepository, AssuntoRepository>();
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<ILivroValorRepository, LivroValorRepository>();
        services.AddScoped<ITipoVendaRepository, TipoVendaRepository>();
    }
}

