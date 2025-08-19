using Application.Behaviors;
using Application.Interfaces;
using FluentValidation;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var conn = config.GetConnectionString("DefaultConnection")
                  ?? "Server=localhost;Database=CleanArchDb;Trusted_Connection=True;TrustServerCertificate=True;";

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(conn);
        });

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR (scan Application assembly)
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Behaviors.ValidationBehavior<,>).Assembly));

        // FluentValidation (scan Application assembly)
        services.AddValidatorsFromAssembly(typeof(Application.Behaviors.ValidationBehavior<,>).Assembly);

        // Pipeline behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
