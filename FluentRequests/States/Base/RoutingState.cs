using FluentRequests.Lib.States.Base.TerminationStates;
using FluentRequests.Lib.Validation.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base
{
    internal abstract class RoutingState
    {
        private readonly Rule<RoutingState> _isExitRoutingState
            = Rule<RoutingState>.BeginInit()
                                .FromMethod(s => s is ExitRoutingState)
                                .OnDefaultLevel()
                                .Or(rb => rb.FromMethod(s => s is TerminationRoutingState)
                                            .OnDefaultLevel()
                                            .EndInit())
                                .EndInit();
        
        public int PassedArgumentsAmount { get; set; }

        public double RoutingPersentage { get; set; }

        protected IRoutingContext Context { get; set; }
        
        public abstract string Execute();
       
        public abstract Task<string> ExecuteAsync();

        public abstract void Route(IEnumerable<string> argumetns);

        public void SetContext(IRoutingContext context)
        {
            Context = context;
        }

        public bool CanRoute() 
            => _isExitRoutingState.Validate(this) == false;

    }
}
