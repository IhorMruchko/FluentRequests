using System.IO;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    internal class DeconvertAttribute : RemoveFileAttribute
    {
        public DeconvertAttribute(string directory=Constants.AttributesDirectory) : base(directory)
        {
        }

        protected override string GetFileName(MethodInfo method) 
            => Path.Combine(method.DeclaringType.Name, method.Name + "Attribute" + Constants.FileExtension);
    }
}
