using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class Question6Controller : ApiController
    {
        /// <summary>
        /// Method returns 3 strings that have the fortnights total and how much per, as well as total tax, and the final total
        /// <example> POST api/question6/0</example>
        /// </summary>
        /// <returns> "1 fortnights at $5.50/FN = $5.50 CAD". "HST 13% = $0.72 CAD", "Total = $6.22 CAD" </returns>
        double perNight = 5.50;
        double tax = .13;
        double fortNight = 14;
        double payPeriod;
        double totalTax;
        double total;
        double subTotal;
        public IEnumerable<string> Get(int id)
        {
            payPeriod = Math.Floor(id / fortNight) + 1;
            subTotal = payPeriod * perNight;
            totalTax = subTotal * tax;
            total = subTotal + totalTax;
            return new string[] {
                String.Format("{0} fortnights at {1:C2}/FN = {2:C2} CAD", payPeriod, perNight, subTotal), 
                String.Format("HST 13% = {0:C2} CAD", totalTax), 
                String.Format("Total = {0:C2} CAD", total) };
        }
    }
}
//payPeriod + " fortnights at $5.50/FN = $" + subTotal + " CAD"
//"HST 13% = " + totalTax + " CAD"
//"Total = " + total + " CAD"
