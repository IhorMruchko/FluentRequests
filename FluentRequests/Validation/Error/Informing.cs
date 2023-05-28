namespace FluentRequests.Lib.Validation.Error
{
    public abstract class Informing
    {
        public abstract void OnError(string errorMessage);

        public Informing Max(Informing another) 
            => InformingLevels.GetPriority(this) > InformingLevels.GetPriority(another)
            ? this
            : another;

        public static implicit operator InformingLevel(Informing informing)
            => InformingLevels.GetEnumValue(informing);

        public static implicit operator Informing(InformingLevel level)
            => InformingLevels.GetLevel(level);

    }
}
