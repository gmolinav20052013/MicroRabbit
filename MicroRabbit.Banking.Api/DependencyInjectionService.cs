namespace MicroRabbit.Banking.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            

            return services;
        }
    }
}
