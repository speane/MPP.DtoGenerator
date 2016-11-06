using System.Collections.Generic;
using DtoGenerator.DtoDescriptions;
using Newtonsoft.Json;

namespace DtoGenerator.DtoClass
{
    public class DtoClassDesciption
    {
        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("properties")]
        public List<DtoPropertyDescription> Properties { get; set; }
    }
}
