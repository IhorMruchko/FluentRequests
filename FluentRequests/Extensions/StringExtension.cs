using System.IO;

namespace FluentRequests.Lib.Extensions
{
    public static class StringExtension
    {
        public static void CreateIfNotExists(this string filePath)
        {
            if (Directory.Exists(filePath))
                return;
            Directory.CreateDirectory(filePath);
        }
    }
}
