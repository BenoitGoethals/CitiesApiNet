using System;
using System.IO;
using CitiesApiNet.data;
using CitiesApiNet.Tests.Properties;
using Xunit;

namespace CitiesApiNet.Tests.data
{
    public class CityRepositoryVelocityDbTest:IDisposable
    {
        private readonly IRepositoryCity _repository;

        public CityRepositoryVelocityDbTest()
        {
         //   string file = @"c:\temp\velecityDb";
          //  if (Directory.Exists(file))
            //    Directory.Delete(file, true); // remove our current systemDir and all its databases.
            
            DataJson dataJson = new DataJson(ResourceHelper.GetResourceStream(@"cities.json"));
            var dataVelocityDb = new DataVelocityDb(@"dbvel"+Guid.NewGuid()); 
        //    dataVelocityDb.Dispose();
            dataVelocityDb.AddCity(dataJson.All());
           
            _repository = new CityRepository(dataVelocityDb);
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
            _repository?.Dispose();
        }
    }
}