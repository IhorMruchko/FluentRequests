using System;
using System.IO;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    internal abstract class RemoveFileAttribute : MetaProgrammingAttribute
    {
        public string DirectorySource { get; private set; }
        
        public RemoveFileAttribute(string directory) 
        { 
            DirectorySource = directory;
        }

        public override void Apply(MethodInfo method)
        {
            if (Directory.Exists(DirectorySource) == false) return;
            var filePath = Path.Combine(DirectorySource, GetFileName(method));
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        protected abstract string GetFileName(MethodInfo method);
    }
}
