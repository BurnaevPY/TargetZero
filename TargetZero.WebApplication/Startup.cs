using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TargetZero.Domain;
using TargetZero.Infrastructure.Postgres;
using TargetZero.Infrastructure.Postgres.Repositories;
using TargetZero.WebApplication.Authorization;
using TargetZero.WebApplication.Queries;
using TargetZero.WebApplication.Services;

namespace TargetZero.WebApplication
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
            var connectionString = Configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<TargetZeroContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            //services.AddTransient<IIdentityService, MockIdentityService>();

            services.AddTransient<IQueries>(provider => new PostgresQueries(connectionString));

            services.AddScoped<IInnovationRepository, InnovationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFilialRepository, FilialRepository>();
            services.AddScoped<IInnovationStatusRepository, InnovationStatusRepository>();
            services.AddScoped<IResolutionRepository, ResolutionRepository>();
            services.AddScoped<IConsiderationGroupRepository, ConsiderationGroupRepository>();
            services.AddScoped<IConsiderationRepository, ConsiderationRepository>();
            services.AddScoped<IConsiderationResultRepository, ConsiderationResultRepository>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(DecisionAccess), policy => policy.Requirements.Add(new DecisionAccessRequirement()));
                options.AddPolicy(nameof(ConsiderationAccess), policy => policy.Requirements.Add(new ConsiderationAccessRequirement()));
                options.AddPolicy(nameof(ChangeInnovationAccess), policy => policy.Requirements.Add(new ChangeInnovationAccessRequirement()));
                options.AddPolicy(nameof(InformationSecurityAccess), policy => policy.Requirements.Add(new InformationSecurityAccessRequirement()));
            });

            services.AddTransient<IAuthorizationHandler, DecisionAccessHandler>();
            services.AddTransient<IAuthorizationHandler, ConsiderationAccessHandler>();
            services.AddTransient<IAuthorizationHandler, ChangeInnovationAccessHandler>();
            services.AddTransient<IAuthorizationHandler, InformationSecurityAccessAccessHandler>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory)
        {
            // миграция БД)))
            using var scope = serviceScopeFactory.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<TargetZeroContext>();
            dbContext.Database.Migrate();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Innovations}/{action=Index}/{id?}");
            });
        }
    }
}
