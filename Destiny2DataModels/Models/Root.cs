using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DestinyLoadoutBuilder.Data.Models
{
    public class Root
    {
        public List<Response> Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }

        public Root()
        {
            Response = new List<Response>();
            MessageData = new MessageData();
        }
    }
 
    public class Response
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

    public class MessageData
    {
    }




}
