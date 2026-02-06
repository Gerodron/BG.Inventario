namespace BG.Inventario.API
{
    public static class DepedencyInjectionServices
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {   
            services.AddControllers();
            services.AddOpenApi();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(
                        "http://localhost:4200"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    ;
                    
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
