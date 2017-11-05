using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Extras.NLog;
using CitiesApiNet.data;
using CitiesApiNet.Models;

namespace CitiesApiNet.Controllers
{
    public class CityController : ApiController
    {
        private readonly IRepositoryCity _repositoryCity;
        public ILogger Logger { get; set; }
        public CityController(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;
        }

        //      private readonly IRepositoryCity _repositoryCity = new CityRepository(new DataJson(@"c:/temp/cities.json"));

        // GET api/values
        public IEnumerable<City> Get()
        {
            Logger.Info("get all "+DateTime.Now);
            return _repositoryCity.Cities();
        }

        // GET api/values/5
        public HttpResponseMessage Get(double lat,double lang)
        {
            City ret= _repositoryCity.City(lat, lang);
            if (ret == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"city not found");
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }




        // GET api/values/5
        public HttpResponseMessage Get(string city)
        {
            Logger.Info("get "+city);
            var alUrl = ControllerContext.Request.GetQueryNameValuePairs();
            string cou = alUrl.LastOrDefault(x => x.Key == "country").Value;
            if (!string.IsNullOrEmpty(cou))
            {
                var cities = _repositoryCity.Cities(cou);
                if (cities == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "country not found");
                return Request.CreateResponse(HttpStatusCode.OK, cities);
            }
           City ret = _repositoryCity.City(city);
            if (ret == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "city not found");
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }


        /*

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
        */
    }
    
}