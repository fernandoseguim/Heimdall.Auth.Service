using IdentityServer4.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heimdall.Auth.Service.Domain.Entities
{
	public class ClientEntity
    {
	    public string ClientData { get; set; }

	    [Key]
	    public string ClientId { get; set; }

	    [NotMapped]
	    public Client Client { get; set; }
		
	    public void MapDataFromEntity()
	    {
		    this.Client = JsonConvert.DeserializeObject<Client>(this.ClientData);
		    this.ClientId = this.Client.ClientId;
	    }
	}
}
