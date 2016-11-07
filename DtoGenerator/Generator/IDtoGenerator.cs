using DtoGenerator.Dto.Description;

namespace DtoGenerator.Generator
{
    public interface IDtoGenerator
    {
        string GenerateClassDescriptionBody(DtoClassDescription classDesciption);
    }
}
