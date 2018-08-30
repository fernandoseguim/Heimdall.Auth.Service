using IdentityServer4.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heimdall.Auth.Service.Domain.Entities
{
	public class IdentityResourceEntity
    {
	    public string IdentityResourceData { get; set; }

	    [Key]
	    public string IdentityResourceName { get; set; }

	    [NotMapped]
	    public IdentityResource IdentityResource { get; set; }
		
	    public void MapDataFromEntity()
	    {
		    this.IdentityResource = JsonConvert.DeserializeObject<IdentityResource>(this.IdentityResourceData);
		    this.IdentityResourceName = this.IdentityResource.Name;
	    }
	}
}
