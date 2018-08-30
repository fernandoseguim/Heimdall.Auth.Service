using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityServer4.Models;
using Newtonsoft.Json;

namespace Heimdall.Auth.Service.Domain.Entities
{
	public class ApiResourceEntity
	{
	    public string ApiResourceData { get; set; }

	    [Key]
	    public string ApiResourceName { get; set; }

	    [NotMapped]
	    public ApiResource ApiResource { get; set; }
		
	    public void MapDataFromEntity()
	    {
		    this.ApiResource = JsonConvert.DeserializeObject<ApiResource>(this.ApiResourceData);
		    this.ApiResourceName = this.ApiResource.Name;
	    }
	}
}
