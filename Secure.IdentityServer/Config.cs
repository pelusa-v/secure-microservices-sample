using IdentityServer4.Models;

namespace Secure.IdentityServer;

public class Config
{
    public static IEnumerable<Client> Clients => new List<Client>()
    {
        new() 
        {
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientId = "client1",
            ClientSecrets = { new Secret("secret1".Sha256()) },
            AllowedScopes = { "cats.api" },
        },
        new() 
        {
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientId = "client2",
            ClientSecrets = { new Secret("secret2".Sha256()) },
            AllowedScopes = { "dogs.api" },
        }
    };
    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>()
    {
        new ApiScope() {Name = "cats.api"},
        new ApiScope() {Name = "dogs.api"},
    };
    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>();
    public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>();
}
