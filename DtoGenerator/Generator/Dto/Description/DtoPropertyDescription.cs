using Newtonsoft.Json;

namespace DtoGenerator.Dto.Description
{
    public class DtoPropertyDescription
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
