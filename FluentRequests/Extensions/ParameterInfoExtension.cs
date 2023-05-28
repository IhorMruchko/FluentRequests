using System;
using System.Reflection;

namespace FluentRequests.Lib.Extensions
{
    public static class ParameterInfoExtension
    {
        public static string IsParams(this ParameterInfo info)
            => info.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0
            ? "params "
            : string.Empty;

        public static string Display(this ParameterInfo info)
            => info.IsOptional
            ? ""
            : info.IsParams() + info.ParameterType.CodeName() + " " + info.Name;
    }
}
