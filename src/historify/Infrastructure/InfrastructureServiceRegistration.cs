using Application.Services.ImageService;
using Historify.Infrastructure.Abstractions;
using Historify.Infrastructure.Storage;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddScoped<IStorageService, StorageManager>();


        return services;
    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : BaseStorage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }


}
