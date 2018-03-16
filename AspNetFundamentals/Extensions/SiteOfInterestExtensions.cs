using System;
using System.Linq;
using AspNetFundamentals.Services.Model;

namespace AspNetFundamentals.Extensions
{
    public static class SiteOfInterestExtensions
    {
        public static bool MatchesSearch(this PlaceOfInterest placeOfInterest, string search)
        {
            //Temporal check until constraint is enabled in controller
            if (search == null) search = string.Empty;

            return placeOfInterest.Name.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                   placeOfInterest.Address.AddressLine.IndexOf(search, StringComparison.InvariantCulture) >= 0;
        }

        public static bool Search(this PlaceOfInterest placeOfInterest, string search)
        {
            var words = search.Split(" ").Where(w => w.Length > 3);
            bool match = false;

            foreach (var word in words)
            {
                if (match) break;
                match = MatchesSearch(placeOfInterest, word);
            }

            return match;
        }
    
    }
}
