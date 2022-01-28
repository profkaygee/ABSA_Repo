using Newtonsoft.Json;
using System;

namespace ABSA_Assessment.Core.DTO
{
    public class PhonebookDto : BaseDto
    {
        [JsonProperty("PhonebookId")]
        public Guid PhonebookId { get; set; }

        [JsonProperty("BookName")]
        public string BookName { get; set; }
    }
}