using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Autofac.Extras.NLog;
using CitiesApiNet;
using CitiesApiNet.Controllers;
using CitiesApiNet.data;
using CitiesApiNet.Models;

using Xunit;

namespace CitiesApiNet.Tests.Controllers
{
    public class CityControllerTests
    {
        [Fact()]
        public void CityControllerTest()
        {

            CityController cityController=new CityController(new CityRepository(new DataJson(ResourceHelper.GetResourceStream(@"cities.json"))));
            cityController.Logger = new NullLogger();
            IEnumerable<City> result = cityController.Get();

            // Assert
            Assert.NotNull(result);
           Assert.True(result.Count()>1); 
            
        }
        /*
        [Fact]
        public void GetCityByNameTest()
        {
            CityController cityController = new CityController(new CityRepository(new DataJson(ResourceHelper.GetResourceStream(@"cities.json"))));
            cityController.Logger = new NullLogger();
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
            

            Assert.NotNull(cityController.Get("les Escaldes"));
        }


        [Fact]
        public void GetCityByCountryTest()
        {
            CityController cityController = new CityController(new CityRepository(new DataJson(ResourceHelper.GetResourceStream(@"cities.json"))));
            cityController.Logger = new NullLogger();
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             

            Assert.True(cityController.Get("AD").IsSuccessStatusCode);
        }

        [Fact]
        public void GetCityByCoordTest()
        {
            CityController cityController = new CityController(new CityRepository(new DataJson(ResourceHelper.GetResourceStream(@"cities.json"))));
            cityController.Logger = new NullLogger();
            /*
             {
      "country": "AD",
      "name": "les Escaldes",
      "lat": "42.50729",
      "lng": "1.53414"
    },
             * 
             

            Assert.True(cityController.Get(42.50729,  1.53414).IsSuccessStatusCode);
        }

    */
    }
}