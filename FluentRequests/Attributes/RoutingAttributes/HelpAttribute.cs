using System;

namespace FluentRequests.Lib.Attributes.RoutingAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Parameter)]
    internal class HelpAttribute : Attribute
    {
        public string Help { get; private set; }
        
        public HelpAttribute(string helpDescription)
        {
            Help = helpDescription;
        }
    }
}
