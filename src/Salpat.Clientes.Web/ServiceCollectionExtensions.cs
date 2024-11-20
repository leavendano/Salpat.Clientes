namespace Salpat.Clientes.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBrowserTimeProvider(this IServiceCollection services)
        => services.AddSingleton<TimeProvider, BrowserTimeProvider>();
}