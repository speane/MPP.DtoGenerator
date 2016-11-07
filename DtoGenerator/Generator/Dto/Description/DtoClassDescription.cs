using System.Collections.Generic;
using DtoGenerator.DtoDescriptions;
using Newtonsoft.Json;

namespace DtoGenerator.Dto.Description
{
    public class DtoClassDescription
    {
        [JsonIgnore]
        public string Namespace { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("properties")]
        public List<DtoPropertyDescription> Properties { get; set; }
    }
}
