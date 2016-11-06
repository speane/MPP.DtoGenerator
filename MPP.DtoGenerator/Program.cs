using DtoGenerator.DtoClass;
using MPP.DtoGenerator.ClassReader;

namespace MPP.DtoGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filename = "dto.txt";

            IDtoDescriptionFileReader descriptionReader = new JsonClassFileReader();

            DtoDescriptionDocument document = descriptionReader.ReadDtoDescription(filename);


        }
    }
}
