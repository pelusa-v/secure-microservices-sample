using IdentityServer4.Models;

namespace Secure.IdentityServer;

public class Config
{
    public static IEnumerable<Client> Clients => new List<Client>()
    {
        new() 
        {
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            // AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientId = "client",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "secretAPI" },
        }
    };
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
    {
        new ApiScope() {Name = "secretAPI"},
    };
    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>();
    public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>();
}
