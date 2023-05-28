using System;

namespace FluentRequests.Lib.Validation.Error
{
    public class Information : Informing
    {
        public override void OnError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
