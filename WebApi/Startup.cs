using Business.Friends;
using Business.HistoricoLog;
using Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.General;
using Repository.General;
using WebApi.Middlewares;

namespace WebApi
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
            services.AddDbContext<SolutionContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddMvc();

            // Register application services.            
            services.AddScoped<IBFriend, BFriend>();
            services.AddScoped<IBCalculoHistoricoLog, BCalculoHistoricoLog>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Map("/middelware", b =>
            {
                b.UseMiddleware<BasicAuthMiddleware>();
                b.UseMvc();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
