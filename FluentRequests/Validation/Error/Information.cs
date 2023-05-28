using System;

namespace FluentRequests.Lib.Validation.Error
{
    public class Information : ValidationState
    {
        public override void OnError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
