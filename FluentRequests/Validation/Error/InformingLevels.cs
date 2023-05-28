using FluentRequests.Lib.Extensions;
using System;
using System.Collections.Generic;

namespace FluentRequests.Lib.Validation.Error
{
    public static class InformingLevels
    {
        private static Dictionary<InformingLevel, Informing> _fromEnumToClass
            = new Dictionary<InformingLevel, Informing>()
            {
                [InformingLevel.Ignore] = new Ignore(),
                [InformingLevel.Information] = new Information(),
                [InformingLevel.Warning] = new Warning(),
                [InformingLevel.Error] = new Error(),
                [InformingLevel.Critical] = new Critical(),
            };

        public static Informing Ignore => new Ignore();

        public static Informing Info => new Information();

        public static Informing Warn => new Warning();

        public static Informing Error => new Error();

        public static Informing Critical => new Critical();

        public static Informing GetLevel(InformingLevel level)
            => _fromEnumToClass.TryGetValue(level, out var value) ? value : new Ignore();

        public static int GetPriority(Informing level)
            => _fromEnumToClass.ContainsValue(level) ? (int)GetEnumValue(level) : -1;

        internal static InformingLevel GetEnumValue(Informing informing) 
            => _fromEnumToClass.GetKey(informing);
    }
}
