using Newtonsoft.Json;

namespace BankingSystem.AuthService.BankingSystem.DataAccess.Entities
{

    /// <summary>
    /// Represent a Keycloak's user that will be added in the server
    /// </summary>
    public class KeycloakUser
    {
        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("credentials")]
        public List<Credential>? Credentials { get; set; }
    }
}
