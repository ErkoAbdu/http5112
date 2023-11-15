using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeasonApp.Models;

namespace SeasonApp.Controllers
{
    public class SeasonAPIController : ApiController
    {
        [Route("api/SeasonAPI/GetSeason/{temperature}")]
        public Season GetSeason(int? temperature)
        {
            string season = "";
            string author = "";
            string img = "";
            if (temperature == null)
            {
                season = "unknown";
                author = "unknown";
                img = "unknown";
            };
            if (temperature > 20)
            {
                season = "Summer";
                author = "Erko";
                img = "#";
            }
            else if (temperature >= 15)
            {
                season = "Fall";
                author = "Erko";
                img = "#";
            }
            else if (temperature > 10)
            {
                season = "Spring";
                author = "Erko";
                img = "#";
            }
            else
            {
                season = "Winter";
                author = "Erko";
                img = "#";
            }
            Season SeasonInfo = new Season();
            SeasonInfo.SeasonName = season;
            SeasonInfo.PhotographerName = author;   
            SeasonInfo.ImageURL = img;

            //string message = "The season is " + season + "!";
            return SeasonInfo;
        }
    }

}