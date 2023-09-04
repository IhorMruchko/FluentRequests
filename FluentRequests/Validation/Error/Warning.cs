using System;

namespace FluentRequests.Lib.Validation.Error
{
    public class Warning : Informing
    {
        public override void OnError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
