using System;
using System.IO;
using CitiesApiNet.data;
using Xunit;

namespace CitiesApiNet.Tests.data
{
    public class DataVelocityDbTests:IDisposable
    {
        private readonly DataVelocityDb _dataVelocityDb;
        public DataVelocityDbTests()
        {
            DataJson dataJson = new DataJson(ResourceHelper.GetResourceStream(@"cities.json"));
            _dataVelocityDb = new DataVelocityDb(@"dbvel" + Guid.NewGuid());
         //   _dataVelocityDb.Dispose();
       //     if (Directory.Exists(_dataVelocityDb.SystemDir))
         //       Directory.Delete(_dataVelocityDb.SystemDir, true); // remove our current systemDir and all its databases.
            _dataVelocityDb.AddCity(dataJson.All());
           
        }

        
        

        [Fact()]
        public void AllTest()
        {
            Assert.NotNull(_dataVelocityDb.All());
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

            Assert.NotNull(_dataVelocityDb.City("les Escaldes"));
        }

        [Fact]
        public void GetCityByNameNoFoundTest()
        {
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             */

            Assert.Null(_dataVelocityDb.City("les"));
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

            Assert.NotNull(_dataVelocityDb.Cities("AD"));
        }


        [Fact]
        public void GetCityByCountryBadCountryTest()
        {
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             */

            Assert.NotNull(_dataVelocityDb.Cities("AAD"));
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

            Assert.Equal("les Escaldes", _dataVelocityDb.City(42.50729, longitute: 1.53414).Name);
        }


        public void Dispose()
        {
            _dataVelocityDb?.Dispose();
        }
    }
}