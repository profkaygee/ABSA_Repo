using System;
using Newtonsoft.Json;

namespace ABSA_Assessment.Core.DTO
{
    public abstract class BaseDto
    {
        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("TimeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}