using System.Collections.Generic;
using DtoGenerator.Dto.Description;
using Newtonsoft.Json;

namespace DtoGenerator.DtoClass
{
    public class DtoDescriptionDocument
    {
        [JsonProperty("classDescriptions")]
        public List<DtoClassDescription> ClassDescriptions { get; set; }
    }
}
