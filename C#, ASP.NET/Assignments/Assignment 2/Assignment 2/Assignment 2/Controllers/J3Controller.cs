using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Was supposed to input number of people as well as their schedules and output the days (1-5) that majority of people can attend
        /// </summary>
        /// <param name="numPeople"></param>
        /// <exmaple>GET api/J3/2/yyy../..yyy</exmaple>
        /// <returns>Day 3</returns>
        //J3 Question Source:https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2023/ccc/juniorEF.pdf
        [Route("api/J3/{numPeople}/{array?}")]
        [HttpGet]

        public int Get(int numPeople)
        {
            string[] schedule = new string[numPeople];
            int[] available = new int[5];
            for (int i = 0; i < numPeople; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (schedule[i][j] == 'Y')
                    {
                        available[i]++;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
                {
                    
                }
        }
    }
}


/* -----Notes-----
 * need array to hold number of days
 * need variable to randomize whether numPeople will return as Y or .
 * need array to = numPeople randomized
 * need variable 
 */
//(days + attend) * numPeople;
/*
            var rand = new Random();
            string schedule = numPeople.ToString();
            string[] days = new string[numPeople];

            for (int attend = 0; attend < numPeople; attend++)
            {
                if (rand.Next(2) == 1)
                {
                    days[attend] = "Y";
                }
                else
                {
                    days[attend] = ".";
                }
            }
            string randSched = days * numPeople;
            return randSched;*/