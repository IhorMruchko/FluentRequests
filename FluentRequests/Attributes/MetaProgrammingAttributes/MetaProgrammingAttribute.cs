using System;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal abstract class MetaProgrammingAttribute : Attribute
    {
        public abstract void Apply(MethodInfo method);
    }
}
