using poketra_vyrt_api.Infrastructure.Repository;

namespace poketra_vyrt_api.Infrastructure;

public static class InfaExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        return services;
    }
}