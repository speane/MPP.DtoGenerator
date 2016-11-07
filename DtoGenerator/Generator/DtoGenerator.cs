using DtoGenerator.Dto.Description;
using DtoGenerator.Generator.Dto;

namespace DtoGenerator.Generator
{
    public class DtoGenerator : IDtoGenerator
    {
        public string GenerateClassDescriptionBody(DtoClassDescription classDesciption)
        {
            DtoClass dtoClass = new DtoClass(classDesciption);
            return dtoClass.GenerateCSharpCode();
        }
    }
}
