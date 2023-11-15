using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DynamicWebPages.Controllers
{
    public class ExampleController : ApiController
    {
        [Route("api/example/season/{temperature}")]
        public string GetSeason(int temperature)
        {
            string season = "";
            if (temperature > 20)
            {
                season = "Summer";
            }
            else if (temperature >= 15)
            {
                season = "Fall";
            }
            else if (temperature > 10)
            {
                season = "Spring";
            }
            else
            {
                season = "Winter";
            }
            string message = "The season is " + season + "!";
            return message;
        }
    }
}
