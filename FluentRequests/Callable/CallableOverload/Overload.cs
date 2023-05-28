using FluentRequests.Lib.Building;
using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.Arguments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable.CallableOverload
{
    public class Overload : ICallable, IExecutable
    {
        public static IHelpSetter<IParametersSetter> BeginInit()
            => new OverloadBuilder();

        internal string Help { get; set; }

        internal Func<List<ArgumentBase>, List<ArgumentBase>, string> Body { get; set; }

        internal List<ArgumentBase> RequiredArguments { get; set; } = new List<ArgumentBase>();

        internal List<ArgumentBase> OptionalArguments { get; set; } = new List<ArgumentBase>();
       
        public bool IsCalled(IEnumerable<string> arguments)
        {
            throw new System.NotImplementedException();
        }

        public string Execute() 
            => Body(RequiredArguments, OptionalArguments);

        public async Task<string> ExecuteAsync() 
            => await Task.FromResult(Body(RequiredArguments, OptionalArguments));
    }
}
