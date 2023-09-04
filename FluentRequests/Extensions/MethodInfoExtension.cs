using FluentRequests.Lib.Callable.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Extensions
{
    public static class MethodInfoExtension
    {
        public static Func<List<ArgumentBase>, List<ArgumentBase>, string> ToRoutingMethod(this MethodInfo source) => (req, opt)
            => source.ToInvoke(req, opt);

        private static string ToInvoke(this MethodInfo source, List<ArgumentBase> req, List<ArgumentBase> opt)
        {
            var arguments = req.Concat(opt).ToList();
            
            source.Decompose()
                  .Get(m => m.GetParameters())
                  .Decompose()
                  .Get(p => p.Select(param => arguments.ValueOf(param.Name, param.ParameterType)).ToArray(), out var parameters);

            return source.Invoke(null, parameters).ToString();

        }
    }
}
