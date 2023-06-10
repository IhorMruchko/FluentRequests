using FluentRequests.Lib.Decomposition;

namespace FluentRequests.Lib.Extensions
{
    public static class DecomposeExtension
    {
        public static Decomposer<TTarget> Decompose<TTarget>(this TTarget target)
            => new Decomposer<TTarget>(target);

        public static Decomposer<TTarget> Decompose<TTarget>(this TTarget target, out TTarget result)
        {
            result = target;
            return Decompose(target);
        }
    }
}
