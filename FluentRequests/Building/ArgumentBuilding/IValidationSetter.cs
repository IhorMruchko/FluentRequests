﻿using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IValidationSetter<TArgumentObject, TArgument> : 
        IArgumentFinalizer<TArgumentObject, TArgument>
    {
        IConstraintOnlySetter<TArgumentObject, TArgument> WithValidator(Rule<TArgument> validation);
    }
}