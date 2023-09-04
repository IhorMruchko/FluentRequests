using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class ArgumentIsNotConvertedTerminationRoutingState : TerminationRoutingState
    {
        public Type Type { get; internal set; }
        public string Value { get; internal set; }

        public override string Execute() 
            => $"Can not convert {Value} to the type {Type}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
        }
    }
}