using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Stockholm;


namespace R5T.Megara.Stockholm.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> service.
        /// </summary>
        public static IServiceCollection AddFileSerializer<T>(this IServiceCollection services,
            ServiceAction<IStreamSerializer<T>> addStreamSerializer)
        {
            services.AddStreamFileSerializer(addStreamSerializer);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSerializer{T}"/> service.
        /// </summary>
        public static ServiceAction<IFileSerializer<T>> AddFileSerializerAction<T>(this IServiceCollection services,
            ServiceAction<IStreamSerializer<T>> addStreamSerializer)
        {
            var serviceAction = new ServiceAction<IFileSerializer<T>>(() => services.AddFileSerializer<T>(addStreamSerializer));
            return serviceAction;
        }
    }
}
