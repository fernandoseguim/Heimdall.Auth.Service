using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Heimdall.Auth.Service.Infra.Store
{
    public class ClientStore : IClientStore
    {

	    private readonly AuthenticationServiceContext context;

	    public ClientStore(AuthenticationServiceContext context)
	    {
		    this.context = context;
	    }

	    public Task<Client> FindClientByIdAsync(string clientId)
		{
			var client = this.context.Clients.First(t => t.ClientId == clientId);
			client.MapDataFromEntity();
			return Task.FromResult(client.Client);
		}
	}
}
