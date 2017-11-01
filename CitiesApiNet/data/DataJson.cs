using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using CitiesApiNet.Models;
using Newtonsoft.Json;

namespace CitiesApiNet.data
{
    public class DataJson:IDataSourceCIty,IDisposable 
    {
        private  ConcurrentBag<City> _concurrentBag;

        private readonly string _fileName;
        

        public DataJson(string file)
        {
            _fileName = file;
            _concurrentBag = new ConcurrentBag<City>((IEnumerable<City>)DeserializJsonFile());
        }


        private List<City> DeserializJsonFile()
        {
            List<City> list;

            using (StreamReader file = File.OpenText(_fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                list = (List<City>)serializer.Deserialize(file, typeof(IList<City>));
            }

            return list;
        }


        public List<City> Cities(string countryCode)
        {
            return _concurrentBag.Where(c => c.Country == countryCode).ToList();
        }

        public City City(double latitude, double longitute)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {

                NumberGroupSeparator = ".",
                NumberGroupSizes = new int[] { 2 }
            };
            return _concurrentBag.SingleOrDefault(c => longitute.Equals(Convert.ToDouble(c.Lng, provider)) &&
                                                                   latitude.Equals(Convert.ToDouble(c.Lat, provider)));

        }

        public City City(string name)
        {
            return _concurrentBag.SingleOrDefault(c => c.Name.Equals(name));
        }


        public List<City> All()
        {
            return _concurrentBag.ToList();
        }

       

        public void Dispose()
        {
            _concurrentBag = null;
        }
    }
}