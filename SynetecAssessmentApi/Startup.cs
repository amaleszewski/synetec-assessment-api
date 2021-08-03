using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Company.QueryHandlers;
using SynetecAssessmentApi.Application.Company.Validators;
using SynetecAssessmentApi.Application.Profiles;
using SynetecAssessmentApi.Domain.Abstraction;
using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi
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
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SynetecAssessmentApi", Version = "v1" });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerGenNewtonsoftSupport();
            
            services.Scan(
                a => a.FromApplicationDependencies()
                    .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            
            services.Scan(
                a => a.FromApplicationDependencies()
                    .AddClasses(c => c.AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
            
            services.Scan(
                a => a.FromApplicationDependencies()
                    .AddClasses(c => c.AssignableTo(typeof(IDomainService)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
            
            services.AddMediatR(typeof(GetAllEmployeesQueryHandler));
            
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateCompanyBonusPoolCommandValidator>());

            services.AddDbContextPool<DbContext, AppDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Configuration.GetConnectionString("Database")));

            services.AddAutoMapper(typeof(MapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SynetecAssessmentApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
