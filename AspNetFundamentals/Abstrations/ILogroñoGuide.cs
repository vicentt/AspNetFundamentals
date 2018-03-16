
using AspNetFundamentals.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AspNetFundamentals.Abstrations
{
    public interface ILogroñoGuide
    {
        IList<PlaceOfInterest> GetPlacesOfInterest();
        void AddPlaceOfInterest(PlaceOfInterest place);
    }
}
