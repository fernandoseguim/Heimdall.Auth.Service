using Heimdall.Auth.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heimdall.Auth.Service.Infra
{
	public class AuthenticationServiceContext : DbContext
	{
		public AuthenticationServiceContext(DbContextOptions<AuthenticationServiceContext> options) : base(options) { }

		public DbSet<ClientEntity> Clients { get; set; }
		public DbSet<ApiResourceEntity> ApiResources { get; set; }
		public DbSet<IdentityResourceEntity> IdentityResources { get; set; }
	}
}
