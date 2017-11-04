using System;
using CitiesApiNet.data;
using Newtonsoft.Json;
using Xunit;

namespace CitiesApiNet.Tests.data
{

    public class DatJsonTest:IDisposable
    {
        private readonly IDataSourceCIty _dataJson;
      

        public DatJsonTest()
        {
         
            _dataJson = new DataJson(ResourceHelper.GetResourceStream(@"cities.json"));

          //  _dataJson = new DataJson(@"c:\temp\cities.json");
        }


        [Fact]
        public void ReadAllCitiesFromJsonFile()
        {
          

            Assert.NotEmpty(_dataJson.All());
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

            Assert.NotNull(_dataJson.City("les Escaldes"));
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

            Assert.NotNull(_dataJson.Cities("AD"));
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

            Assert.Equal("les Escaldes", _dataJson.City(42.50729, longitute: 1.53414).Name);
        }



        [Fact]
        public void GetCityByCountrySerializeTest()
        {
            /*
             {
        "country": "AD",
        "name": "les Escaldes",
        "lat": "42.50729",
        "lng": "1.53414"
      },
             */
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            Assert.NotNull(_dataJson.Cities("AD"));
            String s = JsonConvert.SerializeObject(_dataJson.Cities("AD"),jss);

        }


        public void Dispose()
        {
            _dataJson.Dispose();
        }

       
    }
}