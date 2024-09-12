using NLogWebApiDemo.Contracts;

namespace NLogWebApiDemo.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
