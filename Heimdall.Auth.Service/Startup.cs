using Heimdall.Auth.Service.Infra;
using Heimdall.Auth.Service.Infra.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Heimdall.Auth.Service
{
	public class Startup
    {
	    private readonly IHostingEnvironment environment;

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.Configuration = configuration;
	        this.environment = environment;
        }

        public IConfiguration Configuration { get; }
		        
        public void ConfigureServices(IServiceCollection services)
        {
			var signingConfigurations = new SigningConfigurations();
	        services.AddSingleton(signingConfigurations);

			services.AddEntityFrameworkSqlServer()
		        .AddDbContext<AuthenticationServiceContext>(
			        options => options.UseSqlServer(this.Configuration.GetConnectionString("AuthenticationServiceContext")));

			services.AddMvc();
	        services.AddIdentityServer()
				.AddSigningCredential(signingConfigurations.SigningCredentials)
				.AddResourceStore<ResourceStore>()			
		        .AddClientStore<ClientStore>();
        }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			app.UseIdentityServer();

			app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
