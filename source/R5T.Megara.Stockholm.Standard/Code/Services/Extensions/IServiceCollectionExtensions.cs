using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Stockholm;


namespace R5T.Megara.Stockholm.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> service implmentation.
        /// </summary>
        public static IServiceCollection AddStreamFileSerializer<T>(this IServiceCollection services)
        {
            services.AddSingleton<IFileSerializer<T>, StreamFileSerializer<T>>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> and the <typeparamref name="TStreamSerializer"/> <see cref="IStreamSerializer{T}"/> implementation.
        /// </summary>
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
