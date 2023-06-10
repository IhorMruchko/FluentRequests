namespace FluentRequests.Lib.Validation.Base
{
    public class NotRule<TValue> : Rule<TValue>
    {
        protected override string ConstraintPattern => "should not fit constraint";

        public override bool Validate(object value)
        {
            if (ValidateType(value, out var typedValue) == false)
                return false;

            if (Constraint(typedValue) == false)
            {
                PreviousResult = true;
                return true;
            }

            PreviousResult = false;
            return false;
        }

        internal override Rule<TValue> Not()
        {
            return new UnaryRule<TValue>()
            {
                PropertiesSelector = PropertiesSelector,
                Constraint = v => Constraint(v) == false,
                Level = Level,
                ConstraintDescription = ConstraintDescription
            };
        }
    }
}