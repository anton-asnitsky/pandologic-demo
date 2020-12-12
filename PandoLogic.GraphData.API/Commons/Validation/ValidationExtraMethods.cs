using Commons.Consts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Validation
{
    public static class ValidationExtraMethods
    {
        public static bool BeValidGuid(Guid guid) =>
            !Equals(guid, Guid.Empty);

        public static bool BeValidEnum<EnumType>(int val) =>
            Enum.IsDefined(typeof(EnumType), val);

    }
}