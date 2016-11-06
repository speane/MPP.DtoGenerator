using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoGenerator.DtoClass;

namespace DtoGenerator.Generator
{
    public interface IDtoGenerator
    {
        string GenerateClassDescriptionBody(DtoClassDesciption classDesciption);
    }
}
