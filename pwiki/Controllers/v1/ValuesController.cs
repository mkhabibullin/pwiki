using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pwiki.Controllers.v1
{
    /// <summary>
    /// Test Controller
    /// </summary>
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        /// <summary>
        /// Test GET Method
        /// </summary>
        /// <remarks>
        /// NOTE: There is some test info here. 
        /// Only for test Swagger
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <returns>Return some constants</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string[]), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
