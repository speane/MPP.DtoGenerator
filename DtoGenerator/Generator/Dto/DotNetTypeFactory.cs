using System;
using System.Collections.Generic;

namespace DtoGenerator.Generator.Dto
{
    internal class DotNetTypeFactory
    {
        private Dictionary<Tuple<string, string>, Type> _dotNetTypes;

        public DotNetTypeFactory()
        {
            _dotNetTypes = new Dictionary<Tuple<string, string>, Type>
            {
                [new Tuple<string, string>("integer", "int32")] = typeof(Int32),
                [new Tuple<string, string>("integer", "int64")] = typeof(Int64),
                [new Tuple<string, string>("number", "float")] = typeof(Single),
                [new Tuple<string, string>("number", "double")] = typeof(Double),
                [new Tuple<string, string>("string", "byte")] = typeof(Byte),
                [new Tuple<string, string>("boolean", "-----")] = typeof(Boolean),
                [new Tuple<string, string>("string", "date")] = typeof(DateTime),
                [new Tuple<string, string>("string", "string")] = typeof(String)
            };
        }

        public Type GetDotNetType(string type, string format)
        {
            return _dotNetTypes[new Tuple<string, string>(type, format)];
        }
    }
}
