using FluentRequests.Lib.Validation.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base
{
    internal abstract class RoutingState
    {
        private readonly Rule<RoutingState> _isStopRoutingStateRule =
            Rule<RoutingState>.BeginInit()
                              .FromMethod(s => s is TerminateRoutingState)
                              .OnDefaultLevel()
                              .Or(rb => rb.FromMethod(s => s is ExitRoutingState)
                                          .OnDefaultLevel()
                                          .EndInit())
                              .Not()
                              .EndInit();

        public static float ValidCommandName = 1f;

        public static float ValidOverload = 0.5f;

        public static float ValidParameters = 0.25f;

        public float RoutingCoefficient { get;  protected set; }

        public RoutingState(IEnumerable<string> args = null)
        {
            Arguments = args;
        }

        protected IEnumerable<string> Arguments { get; set; }

        protected IRoutingSource Source { get; set; }

        public abstract void Route();

        public virtual string Execute()
            => $"Stop routing at {GetType().Name}";

        public virtual async Task<string> ExecuteAsync()
            => await Task.FromResult($"Stop routing at {GetType().Name}");

        public virtual RoutingState SetSource(IRoutingSource source)
        {
            Source = source;
            return this;
        }

        public virtual RoutingState UpdateCoeficient(float increment)
        {
            RoutingCoefficient += increment;
            return this;
        }

        public bool CanContinueRouting()
            => _isStopRoutingStateRule.Validate(this);

    }
}
