using DOTNET_6.Services;

namespace DOTNET_6.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBookStorage(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IBookStorage, BookStorage>();
        }
    }
}
