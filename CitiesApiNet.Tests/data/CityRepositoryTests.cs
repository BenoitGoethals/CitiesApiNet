using System;
using CitiesApiNet.data;
using CitiesApiNet.Models;
using Xunit;


namespace CitiesApiNet.Tests.data
{
    public class CityRepositoryTests:IDisposable
    {

        private  IRepositoryCity _repository;

        public CityRepositoryTests()
        {
             _repository = new CityRepository(new DataJson(@"c:\temp\cities.json"));
        }

        [Fact()]
        public void CitiesTest()
        {
           
          
            Assert.NotEmpty(_repository.Cities());
          
        }



        [Fact]
        public void GetCityByNameTest()
        {
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             */

            Assert.NotNull(_repository.City("les Escaldes"));
        }


        [Fact]
        public void GetCityByCountryTest()
        {
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             */

            Assert.NotNull(_repository.Cities("AD"));
        }

        [Fact]
        public void GetCityByCoordTest()
        {
            /*
             {
      "country": "AD",
      "name": "les Escaldes",
      "lat": "42.50729",
      "lng": "1.53414"
    },
             * 
             */

            Assert.Equal("les Escaldes", _repository.City(42.50729, longitute: 1.53414).Name);
        }



        public void Dispose()
        {
            _repository = null;
        }
    }
}