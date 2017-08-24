using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeathValley.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> GetAllItems()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string GetItem(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void CreateItem([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void EditItem(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void DeleteItem(int id)
        {
        }
    }
}
