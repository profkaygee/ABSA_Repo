using System;
using Newtonsoft.Json;

namespace ABSA_Assessment.Core.DTO
{
    public class PhonebookEntryDto : BaseDto
    {
        [JsonProperty("PhoneEntryId")]
        public Guid PhoneEntryId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("PhonebookId")]
        public Guid PhonebookId { get; set; }
    }
}