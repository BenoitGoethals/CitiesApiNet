using CitiesApiNet.Models;

using Xunit;

namespace CitiesApiNet.Tests.Models
{
   
    public class CityTests
    {
        [Fact]
        public void CityNotEqualTest()
        {
            City city=new City("BE","Gent", "51.054342", "3.717424");
            City city2 = new City("BE", "Drongen", "51.054342", "3.717424");
          
            Assert.NotEqual(city,city2);

        }


        [Fact]
        public void CityEqualTest()
        {
            City city = new City("BE", "Gent", "51.054342", "3.717424");
            City city2 = new City("BE", "Gent", "51.054342", "3.717424");

            Assert.Equal(city, city2);

        }

        [Fact]
        public void CityMgrslTest()
        {
            City city = new City("BE", "Gent", "51.054342", "3.717424");
            City city2 = new City("BE", "Gent", "51.054342", "3.717424");

            Assert.Equal("31U ES 50282 56112", city.Mgrs);

        }


    }
}