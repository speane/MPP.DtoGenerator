using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DtoGenerator.DtoClass
{
    public class DtoDescriptionDocument
    {
        [JsonProperty("classDescriptions")]
        public List<DtoClassDesciption> ClassDesciptions { get; set; }
    }
}
