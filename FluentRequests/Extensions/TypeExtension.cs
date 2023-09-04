using System;
using System.Collections.Generic;

namespace FluentRequests.Lib.Extensions
{
    public static class TypeExtension
    {
        private static readonly Dictionary<Type, string> _primitivesConvertion
            = new Dictionary<Type, string>()
            {
                [typeof(int)] = "int",
                [typeof(long)] = "long",
                [typeof(float)] = "float",
                [typeof(double)] = "double",
                [typeof(bool)] = "bool",
                [typeof(string)] = "string",
                [typeof(object)] = "object",
                [typeof(byte)] = "byte",
                [typeof(char)] = "char"
            };

        public static string CodeName(this Type value)
        {
            if (value.IsArray && _primitivesConvertion.TryGetValue(value.GetElementType(), out var result))
                return result+"[]";
            return _primitivesConvertion.ContainsKey(value) ? _primitivesConvertion[value] : value.Name;
        }
    }
}
