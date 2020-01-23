using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Stockholm;


namespace R5T.Megara.Stockholm.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddStreamFileSerializer<T>(this IServiceCollection services)
        {
            services.AddSingleton<IFileSerializer<T>, StreamFileSerializer<T>>();

            return services;
        }

        public static IServiceCollection AddStreamFileSerializer<T, TStreamSerializer>(this IServiceCollection services)
            where TStreamSerializer: class, IStreamSerializer<T>
        {
            services
                .AddStreamFileSerializer<T>()
                .AddSingleton<IStreamSerializer<T>, TStreamSerializer>()
                ;

            return services;
        }
    }
}
