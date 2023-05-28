using System;

namespace FluentRequests.Lib.Validation.Error
{
    internal class Warning : ValidationState
    {
        public override void OnError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
