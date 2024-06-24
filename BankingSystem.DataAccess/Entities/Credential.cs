using Newtonsoft.Json;

namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represent a Keycloak user's credential in order to set properties
    /// </summary>
    public class Credential
    {
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }
    }
}
