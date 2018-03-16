using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetFundamentals.Abstrations;
using AspNetFundamentals.Extensions;
using AspNetFundamentals.Infractructure.Attributes;
using AspNetFundamentals.Infractructure.ModelBinders;
using AspNetFundamentals.Services.Model;
using AspNetFundamentals.Enums;
using AspNetFundamentals.Infractructure.Filters;
using AspNetFundamentals.Api.Cities.Request;

namespace AspNetFundamentals.Api.Cities
{
    [Route("api/logrono")]
    public class LogroñoController : Controller
    {
        private readonly ILogroñoGuide logroñoGuide;

        public LogroñoController(ILogroñoGuide logroñoGuide)
        {
            this.logroñoGuide = logroñoGuide;
        }
        [HttpGet]
        [Route("places/{format?}"), FormatFilter]
        public IActionResult Index()
        {
            return Ok(logroñoGuide.GetPlacesOfInterest());
        }

        [HttpGet]
        [Route("places/search")]
        //[ShortCircuitResourceFilter]
        [RequiredHeader("Vicen")]
        public IActionResult Search([RequiredFromQuery] string filter)
        {
            return Ok(logroñoGuide.GetPlacesOfInterest()
                     .Where(s => s.MatchesSearch(filter)));
        }

        [HttpGet]
        [Route("places/searchvicen")]
        //[ShortCircuitResourceFilter]
        public IActionResult SearchVicen()
        {
            return Ok("Hola");
        }


        [HttpPost]
        [Route("places")]
        public IActionResult Create([FromBody] CreatePlaceRequest createPlaceRequest)
        {
            logroñoGuide.AddPlaceOfInterest(
                PlaceOfInterest.Create(createPlaceRequest.Name,
                Address.Create(createPlaceRequest.Address)));

            return Ok();
        }
        [HttpPost]
        [Route("places/ask")]
        public IActionResult Ask([ModelBinder(BinderType = typeof(HumanSearchBinder))] HumanSearchRequest humanSearchRequest)
        {
            var targetPlace = logroñoGuide
                              .GetPlacesOfInterest()
                              .FirstOrDefault(s => s.Search(humanSearchRequest.Search));

            string moodMessage = humanSearchRequest.Mood == MoodStatus.Happy
                ? "Nos alegra que este contento, " :
                humanSearchRequest.Mood == MoodStatus.Unhappy ?
                                           "Vamos a intentar animarle,"
                                           : string.Empty;


            return Ok(
                   $"{moodMessage} le recomendamos {targetPlace.Name} en {targetPlace.Address.AddressLine}"
                );

        }

    }
}
