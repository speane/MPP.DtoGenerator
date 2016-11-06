using System.Collections.Generic;
using DtoGenerator.DtoClass;

namespace MPP.DtoGenerator.ClassReader
{
    public interface IDtoDescriptionFileReader
    {
        DtoDescriptionDocument ReadDtoDescription(string filename);
    }
}
