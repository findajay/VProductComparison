using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TariffComparison.JWTAuth;
using TariffComparison.Services;
using TariffComparison.Services.Contract;


namespace TariffComparison
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddTransient<IProductCompare, ProductCompare>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Verivox Tarrif API", Version = "v1" });
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            ConfigureAuthentication(services);
        }

        /// <summary>
        /// Configures the authentication.
        /// </summary>
        private void ConfigureAuthentication(IServiceCollection services)
        {
            // Configure JWT bearer authentication with provided options
            services.AddAuthentication().AddJwtBearer(
                authenticationScheme: JwtAuthenticationDefaults.AuthenticationScheme,
                configureOptions: options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = "https://localhost:44387/tarrif",
                        ValidIssuer = "",
                        ValidateAudience = false,
                        ValidateIssuer =false
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Verivox Tarrif API V1");
            });

        }
    }
}
