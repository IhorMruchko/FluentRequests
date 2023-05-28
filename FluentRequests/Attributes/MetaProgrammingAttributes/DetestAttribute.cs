using System.IO;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    internal class DetestAttribute : RemoveFileAttribute
    {
        protected string[] Parameters { get; set; }

        protected bool WithParameters => TestNumber != 0;

        protected uint TestNumber { get; set; }

        public DetestAttribute(string directory = Constants.TestingDirectory,
            string[] parameter = null,
            uint testNumber = 0) 
            : base(directory)
        {
            Parameters = parameter;
            TestNumber = testNumber;
        }

        protected override string GetFileName(MethodInfo method) 
            => Path.Combine(method.DeclaringType.Name + "Tests", method.Name + 
                (WithParameters ? TestNumber.ToString() : string.Empty) + "Test" + Constants.FileExtension);
    }
}
