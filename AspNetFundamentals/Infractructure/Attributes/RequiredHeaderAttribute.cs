﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetFundamentals.Infractructure.Attributes
{
    public class RequiredHeaderAttribute : Attribute
    {
        public string Header { get; }

        public RequiredHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
