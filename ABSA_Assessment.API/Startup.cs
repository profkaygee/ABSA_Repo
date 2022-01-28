using ABSA_Assessment.Application;
using ABSA_Assessment.Contracts.IRepositories.Commands;
using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using ABSA_Assessment.Infrastructure.Repositories.Commands;
using ABSA_Assessment.Infrastructure.Repositories.Queries;
using ABSA_Assessment.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ABSA_Assessment.API
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
            services.AddDbContext<AbsaContext>(e =>
            {
                e.UseSqlServer(Configuration.GetConnectionString("ABSAConnection"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ABSA_Assessment.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddTransient<IPhonebookCommandRepository, PhonebookCommandRepository>();
            services.AddTransient<IPhonebookQueryRepository, PhonebookQueryRepository>();
            services.AddTransient<IPhonebookEntryCommandRepository, PhonebookEntryCommandRepository>();
            services.AddTransient<IPhonebookEntryQueryRepository, PhonebookEntryQueryRepository>();

            services.AddHealthChecks();

            MapServices(services);
        }

        private static void MapServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ABSA_Assessment.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowAllPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
