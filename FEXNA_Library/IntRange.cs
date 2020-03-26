﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FEXNA_Library
{
    public class IntRange : Range<int>
    {
        public IntRange(int min, int max) : base(min, max) { }

        public IEnumerable<int> Enumerate()
        {
            if (!IsValid())
                throw new ArgumentOutOfRangeException(
                    "Range is invalid for enumeration, maximum must be greater than minimum");
            return Enumerable.Range(Minimum, (Maximum - Minimum) + 1);
        }
    }
}
