using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Heimdall.Auth.Service
{
	public class SigningConfigurations
	{
		public SecurityKey Key { get; }
		public SigningCredentials SigningCredentials { get; }

		public SigningConfigurations()
		{
			using (var provider = new RSACryptoServiceProvider(2048))
			{
				this.Key = new RsaSecurityKey(provider.ExportParameters(true));
			}

			this.SigningCredentials = new SigningCredentials(this.Key, SecurityAlgorithms.RsaSha256Signature);
		}
	}
}
