using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace back
{
    public class Startup
    {
        // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "back", Version = "v1" });
            });
            services.AddCors(options =>
        {
            // options.AddPolicy(name: MyAllowSpecificOrigins,
            //                   builder =>
            //                   {
            //                       builder.WithOrigins("http://example.com",
            //                                           "http://localhost/",
            //                                           "http://localhost/premium",
            //                                           "http://127.0.0.1",
            //                                           "http://127.0.0.1:5500",
            //                                           "http://127.0.0.1/premium",
            //                                           "http://127.0.0.1/")
            //                                           .AllowAnyHeader()
            //                                           .AllowAnyMethod();
                                                      
            //                   });
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "back v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseCors(MyAllowSpecificOrigins);
            app.UseCors();
        }
    }
}
