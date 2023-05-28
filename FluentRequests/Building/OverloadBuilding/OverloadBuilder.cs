using FluentRequests.Lib.Building.ArgumentBuilding;
using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Callable.CallableOverload;
using System;
using System.Collections.Generic;

namespace FluentRequests.Lib.Building.OverloadBuilding
{
    public class OverloadBuilder : IHelpSetter<IParametersSetter>,
                                   IParametersSetter,
                                   IBodySetter, 
                                   IOverloadFinalizer
    {
        private readonly Overload _overload = new Overload();

        public IParametersSetter WithHelp(string helpDescription)
        {
            _overload.Help = helpDescription;
            return this;
        }

        public IParametersSetter WithRequired<TArgument>(RequiredArgument<TArgument> argument)
        {
            _overload.RequiredArguments.Add(argument);
            return this;
        }

        public IParametersSetter WithRequired<TArgument>(Func<IArgumentNameSetter<RequiredArgument<TArgument>, TArgument>, RequiredArgument<TArgument>> argument)
        {
            _overload.RequiredArguments.Add(argument(new RequiredArgumentBuilder<TArgument>()));
            throw new NotImplementedException();
        }

        public IParametersSetter WithOptional<TArgument>(OptionalArgument<TArgument> argument)
        {
            _overload.OptionalArguments.Add(argument);
            throw new NotImplementedException();
        }

        public IParametersSetter WithOptional<TArgument>(Func<IArgumentNameSetter<OptionalArgument<TArgument>, TArgument>, RequiredArgument<TArgument>> argument)
        {
            _overload.RequiredArguments.Add(argument(new OptionalArgumentBuilder<TArgument>()));
            return this;
        }

        public IOverloadFinalizer WithBody(Func<List<ArgumentBase>, List<ArgumentBase>, string> body)
        {
            _overload.Body = body;
            return this;
        }

        public Overload EndInit()
        {
            return _overload;
        }
    }
}
