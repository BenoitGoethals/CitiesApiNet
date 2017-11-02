using System.Collections.Generic;
using CitiesApiNet.data;
using CitiesApiNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CitiesApiNet.Tests.data
{
    [TestClass]
    public class CityRepositryMocqTest
    {
        [TestMethod]
        public void GetCityMocqTest()
        {
            var mock = new Mock<IDataSourceCIty>();
            mock.Setup(x => x.City(It.IsAny<double>(), It.IsAny<double>())).Returns(()=>new City(){});
         
            IRepositoryCity city=new CityRepository(mock.Object);
            Assert.IsNotNull(city.City(4545.555,4554.4455));
            mock.Verify(x => x.City(4545.555, 4554.4455));

        }



        [TestMethod]
        public void AllCityMocqTest()
        {
            var mock = new Mock<IDataSourceCIty>();
            mock.Setup(x =>x.All() ).Returns(() => new List<City>() );

            IRepositoryCity cityRepository = new CityRepository(mock.Object);
            Assert.IsNotNull(cityRepository.Cities());
            mock.Verify(x => x.All());

        }
    }
}
