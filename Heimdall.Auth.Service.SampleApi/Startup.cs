using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Heimdall.Auth.Service.SampleApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthentication("Bearer")
					.AddIdentityServerAuthentication(options =>
					{
						// TODO: remove when go to production
						options.RequireHttpsMetadata = false;

						options.Authority = SampleApiOptions.IDENTITY_SERVER_HOST;
						options.ApiName = SampleApiOptions.API_CLIENT_ID;
					});
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();

			app.UseMvc();
		}
	}
}
