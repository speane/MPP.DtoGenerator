using System.IO;
using DtoGenerator.DtoClass;
using Newtonsoft.Json;

namespace MPP.DtoGenerator.ClassReader
{
    public class JsonClassFileReader : IDtoDescriptionFileReader
    {
        public DtoDescriptionDocument ReadDtoDescription(string filename)
        {
            DtoDescriptionDocument document =
                JsonConvert.DeserializeObject<DtoDescriptionDocument>(File.ReadAllText(filename));
            
            return document;
        }
    }
}
