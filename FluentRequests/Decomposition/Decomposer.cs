using System;

namespace FluentRequests.Lib.Decomposition
{
    public class Decomposer<TTarget>
    {
        private readonly TTarget _target;
        
        public Decomposer(TTarget value) 
        {
            _target = value;
        }

        public Decomposer<TTarget> Get<TResult>(Func<TTarget, TResult> projection, out TResult result)
        {
            result = projection(_target);
            return this;
        }

        public TResult Get<TResult>(Func<TTarget, TResult> projection)
            => projection(_target);
    }
}
