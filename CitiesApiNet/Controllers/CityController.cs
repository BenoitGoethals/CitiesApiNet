using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using CitiesApiNet.data;
using CitiesApiNet.Models;

namespace CitiesApiNet.Controllers
{
    public class CityController : ApiController
    {
        private readonly IRepositoryCity _repositoryCity=new CityRepository(new DataJson());

        // GET api/values
        public IEnumerable<City> Get()
        {
            return _repositoryCity.Cities();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
    
}