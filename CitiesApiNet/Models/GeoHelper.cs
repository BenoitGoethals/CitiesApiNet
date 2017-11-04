using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using CoordinateSharp;


namespace CitiesApiNet.Models
{
    public class GeoHelper
    {

        public static string ConvertToMgrs(double lat, double lng)
        {
            if((lat < -85 || lat >85) || (lng<-180 || lng >180))
              //  throw new ArgumentOutOfRangeException("lat or lng out off range");
              return String.Empty;
            Coordinate c =null;
            try
            {
             //  c = new Coordinate(lat,lng);
                    c= new Coordinate(lat, lng, new DateTime(2017, 8, 21));
            }
            catch (ArgumentOutOfRangeException e)
            {
               return String.Empty;
               
            }
         
            
           
            return c?.MGRS.ToString();
            
        }
    }
}
