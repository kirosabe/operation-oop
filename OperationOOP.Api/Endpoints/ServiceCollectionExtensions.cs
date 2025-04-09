using Microsoft.Extensions.DependencyInjection;
using OperationOOP.Core.Services;
using OperationOOP.Core.Data;

namespace OperationOOP.Api.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IDatabase, Database>(); 
        services.AddScoped<BandService>();
        services.AddScoped<AlbumService>();
        services.AddScoped<SongService>();

        return services;
    }
}