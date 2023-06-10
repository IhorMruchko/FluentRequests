using System.Runtime.InteropServices.ComTypes;

namespace FluentRequests.Lib.Validation.Base
{
    public class UnaryRule<TValue> : Rule<TValue>
    {
        public override bool Validate(object value)
        {
            if (ValidateType(value, out var typedValue) == false)
                return false;

            if (Constraint(typedValue))
            {
                PreviousResult = true;
                return true;
            }
            PreviousResult = false;
            return false;
        }

        internal override Rule<TValue> Not()
        {
            return new NotRule<TValue>()
            {
                PropertiesSelector = PropertiesSelector,
                Constraint = Constraint,
                Level = Level,
                ConstraintDescription = ConstraintDescription
            };
        }
    }
}
