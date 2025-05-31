using Application.Services.ImageService;
using Application.SubServices.StorageService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();

        // Storage servisleri
        services.AddScoped<IStorageService, StorageService>();

        // Varsayılan olarak Azure Storage kullanılacak
        services.AddScoped<IStorage, AzureStorage>();
        services.AddScoped<IAzureStorage, AzureStorage>();

        // Local Storage da eklenebilir
        //services.AddScoped<ILocalStorage, LocalStorage>();

        return services;
    }
}
