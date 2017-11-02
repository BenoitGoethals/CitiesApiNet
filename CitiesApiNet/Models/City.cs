using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using VelocityDb;

namespace CitiesApiNet.Models
{
    public class City : OptimizedPersistable
    {
        [JsonConstructor]
        public City(string country, string name, string lat, string lng)
        {
            Country = country;
            Name = name;
            Lat = lat;
            Lng = lng;
            NumberFormatInfo provider = new NumberFormatInfo
            {
              
                NumberGroupSeparator = ".",
                NumberGroupSizes = new int[] {2}
            };

            Mgrs = GeoHelper.ConvertToMgrs(Convert.ToDouble(lat,provider), Convert.ToDouble(lng, provider));
        }

        public City()
        {
          

        }

        public string Country { get; set; }
        public string Name { get; set; }
       
        public string Lat { get; set; }
      
        public string Lng { get; set; }

        public string Mgrs { get; set; }




        protected bool Equals(City other)
        {
            return string.Equals(Country, other.Country) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((City) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Country != null ? Country.GetHashCode() : 0) * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(City left, City right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(City left, City right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{nameof(Country)}: {Country}, {nameof(Name)}: {Name}, {nameof(Lat)}: {Lat}, {nameof(Lng)}: {Lng}";
        }

        private sealed class CountryNameEqualityComparer : IEqualityComparer<City>
        {
            public bool Equals(City x, City y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Country, y.Country) && string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(City obj)
            {
                unchecked
                {
                    return ((obj.Country != null ? obj.Country.GetHashCode() : 0) * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                }
            }
        }

        public static IEqualityComparer<City> CountryNameComparer { get; } = new CountryNameEqualityComparer();
    }
    /*
      {
    "country": "AD",
    "name": "Ordino",
    "lat": "42.55623",
    "lng": "1.53319"
  },
      
     */

   
}