namespace DestinyLoadoutBuilder.Data.Models
{
    using System.Text.Json.Serialization;
    public class Destiny2Player
    {
        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }

        [JsonPropertyName("crossSaveOverride")]
        public int CrossSaveOverride { get; set; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("membershipType")]
        public int MembershipType { get; set; }

        [JsonPropertyName("membershipId")]
        public string MembershipId { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}
