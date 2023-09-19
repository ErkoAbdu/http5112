using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API_Project.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value3", "value4", "value5" };
        }

        // GET api/values/5
        // input: integer
        //output(square): input squared = (int)Math.Pow(id,2)
        //output(Your input is (integer) !: public string Get(int id), return "Your input is " + id + "!";
        //output(Square root): public int Get(int id), return (int)Math.Sqrt(id);
        public int Get(int id)
        {
            return (int)Math.Sqrt(id);
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
