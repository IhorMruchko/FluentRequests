﻿using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IValidationOnlySetter<TArgumentObject, TArgument> :
        IArgumentFinalizer<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        IArgumentFinalizer<TArgumentObject, TArgument> WithValidator(Rule<TArgument> validation);
    }
}