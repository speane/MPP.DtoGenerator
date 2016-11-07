using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DtoGenerator.Dto.Description;

namespace DtoGenerator.Generator.Dto
{
    internal sealed class DtoClass
    {
        private CodeCompileUnit _targetUnit;
        private CodeTypeDeclaration _targetClass;
        private DotNetTypeFactory _typeFactory;

        public DtoClass(DtoClassDescription description)
        {

            _typeFactory = new DotNetTypeFactory();
            CodeNamespace codeNamespace = new CodeNamespace(description.Namespace);
            _targetUnit = new CodeCompileUnit();

            _targetClass = new CodeTypeDeclaration(description.ClassName)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed
            };
            codeNamespace.Types.Add(_targetClass);
            _targetUnit.Namespaces.Add(codeNamespace);
            foreach (DtoPropertyDescription propertyDescription in description.Properties)
            {
                AddProperty(propertyDescription);
            }
        }

        public void AddProperty(DtoPropertyDescription description)
        {
            CodeMemberProperty property = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = description.Name,
                HasGet = true,
                HasSet = true,
                Type = new CodeTypeReference(
                    _typeFactory.GetDotNetType(description.Type, description.Format))
            };

            _targetClass.Members.Add(property);
        }

        public string GenerateCSharpCode()
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions {BracingStyle = "C"};
            StringBuilder stringBuilder = new StringBuilder();
            TextWriter writer = new StringWriter(stringBuilder);
            provider.GenerateCodeFromCompileUnit(_targetUnit, writer, options);

            return stringBuilder.ToString();
        }
    }
}
