using System;

namespace FluentRequests.Lib.Validation.Error
{
    public class Error : Informing
    {
        public override void OnError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
