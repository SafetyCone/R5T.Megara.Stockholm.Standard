using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.Megara.Stockholm.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddStreamFileSerializer<T>(this IServiceCollection services)
        {
            services.AddSingleton<IFileSerializer<T>, StreamFileSerializer<T>>();

            return services;
        }
    }
}
