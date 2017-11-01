using System;
using System.Diagnostics;
using CoordinateSharp;

namespace CitiesApiNet.Models
{
    public class GeoHelper
    {

        public static string ConvertToMgrs(double lat, double lng)
        {
            Coordinate c =null;
            try
            {
               c = new Coordinate(lat, lng, new DateTime(2017, 8, 21));
            }
            catch (Exception e)
            {
                Debug.WriteLine(lat+"  "+lng);
                Debug.WriteLine(e);
               
            }
          

            return c?.MGRS.ToString();
            
        }
    }
}
