using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CitiesApiNet.Models;

namespace CitiesApiNet.data
{
    public class CityRepository : IRepositoryCity
    {
        private readonly IDataSourceCIty _dataLayerDataSource;


        public CityRepository(IDataSourceCIty dataLayerDataSource)
        {
            _dataLayerDataSource = dataLayerDataSource;
        }

        public List<City> Cities()
        {
            return _dataLayerDataSource.All();
        }

        public List<City> Cities(string countryCode)
        {
            return _dataLayerDataSource.Cities(countryCode);
        }

        public City City(double latitude, double longitute)
        {
            return _dataLayerDataSource.City(latitude, longitute);

        }

        public City City(string name)
        {
            return _dataLayerDataSource.City(name);
        }

        public City GetCity(string name)
        {
            return _dataLayerDataSource.City(name);

        }

        public void Dispose()
        {
            _dataLayerDataSource?.Dispose();
        }
    }
}
