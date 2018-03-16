
using AspNetFundamentals.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetFundamentals.Api.Cities.Request
{
    public class HumanSearchRequest
    {
        public string Search { get; set;}
        public MoodStatus Mood { get; set; }
        public Language Language { get; set; }
    } 
}
