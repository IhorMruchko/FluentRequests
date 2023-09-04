using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IValidationOnlySetter<TArgumentBeforeEnd, TArgument> : IArgumentFinalizer<TArgumentBeforeEnd, TArgument>
    {
        IArgumentFinalizer<TArgumentBeforeEnd, TArgument> WithValidator(Rule<TArgument> validation);
    }
}
