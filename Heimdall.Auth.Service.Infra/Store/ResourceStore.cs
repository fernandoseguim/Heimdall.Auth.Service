using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heimdall.Auth.Service.Domain.Entities;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Heimdall.Auth.Service.Infra.Store
{
	public class ResourceStore : IResourceStore
	{
		private readonly AuthenticationServiceContext context;

		public ResourceStore(AuthenticationServiceContext context)
		{
			this.context = context;
		}

		public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			return Task.FromResult<IEnumerable<IdentityResource>>(new List<IdentityResource>());
		}

		public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

			var apiResourcesEntities = this.context.ApiResources.Where(apiResourcesEntity => scopeNames.Contains(apiResourcesEntity.ApiResourceName)).ToList();
			var apiResources = ConverToApiResources(apiResourcesEntities);

			return Task.FromResult(apiResources.AsEnumerable());
		}

		public Task<ApiResource> FindApiResourceAsync(string name)
		{
			var apiResource = this.context.ApiResources.First(t => t.ApiResourceName == name);

			apiResource.MapDataFromEntity();

			return Task.FromResult(apiResource.ApiResource);
		}

		public Task<Resources> GetAllResourcesAsync()
		{
			var apiResourcesEntities = this.context.ApiResources.ToList();

			var result = new Resources { ApiResources = ConverToApiResources(apiResourcesEntities) };

			return Task.FromResult(result);
		}

		private static List<ApiResource> ConverToApiResources(List<ApiResourceEntity> apiResourcesEntities)
		{
			var apiResources = new List<ApiResource>();

			apiResourcesEntities.ForEach(apiResourceEntity =>
			{
				apiResourceEntity.MapDataFromEntity();
				apiResources.Add(apiResourceEntity.ApiResource);
			});

			return apiResources;
		}
	}
}
