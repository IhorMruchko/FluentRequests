namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    internal abstract class CodeGenerationAttribute : MetaProgrammingAttribute
    {
        public string Directory { get; internal set; }

        public CodeGenerationAttribute(string directory)
        {
            Directory = directory;
        }
    }
}
