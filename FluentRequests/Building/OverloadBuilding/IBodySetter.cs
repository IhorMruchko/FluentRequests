using FluentRequests.Lib.Callable.Arguments;
using System;
using System.Collections.Generic;

namespace FluentRequests.Lib.Building.OverloadBuilding
{
    public interface IBodySetter : IAfterHelpSetter
    {
        IOverloadFinalizer WithBody(Func<List<ArgumentBase>, List<ArgumentBase>, string> body);
    }
}
