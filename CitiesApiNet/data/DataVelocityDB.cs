using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using CitiesApiNet.Models;
using VelocityDb;
using VelocityDb.Session;

namespace CitiesApiNet.data
{
    public class DataVelocityDb : IDataSourceCIty
    {
        //   public static string SystemDir { get; } = "Sample1";


        public string SystemDir { get; set; } = @"c:\temp\VelocityDB";

        public DataVelocityDb(string file)
        {
            SystemDir = file;
            Dispose();

        }

        public DataVelocityDb()
        {
        }

        public void Dispose()
        {
            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {
                session.BeginUpdate();
                DatabaseLocation defaultLocation = session.DatabaseLocations.Default();
                List<Database> dbList = session.OpenLocationDatabases(defaultLocation, true);
                foreach (Database db in dbList)
                    if (db.DatabaseNumber > Database.InitialReservedDatabaseNumbers)
                        session.DeleteDatabase(db);
                session.DeleteLocation(defaultLocation);
                session.Commit();
            }
        }

        public List<City> All()
        {
            List<City> cities;
            using (SessionNoServer session = new SessionNoServer(SystemDir))
            
                {
                    session.BeginRead();
                cities = session.AllObjects<City>().ToList();
               
            }
            return cities;
        }

        public List<City> Cities(string countryCode)
        {
         
            List<City> cities;
            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {
                session.BeginRead();
                cities = session.AllObjects<City>().Where(x=>x.Name.Equals(countryCode)).ToList();

            }
            return cities;
        }

        public City City(double latitude, double longitute)
        {

            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {
                session.BeginRead();
                NumberFormatInfo provider = new NumberFormatInfo
                {

                    NumberGroupSeparator = ".",
                    NumberGroupSizes = new int[] { 2 }
                };

                return session.AllObjects<City>().SingleOrDefault(c =>
                    longitute.Equals(Convert.ToDouble(c.Lng, provider)) &&
                    latitude.Equals(Convert.ToDouble(c.Lat, provider)));

            }

        }

        public City City(string name)
        {

            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {
                session.BeginRead();
                return session.AllObjects<City>().SingleOrDefault(c => c.Name.Equals(name));

            }

        }


        public void AddCity(City city)
        {
            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {

                session.BeginUpdate();

                session.Persist(city);

                session.Commit();
            }
        }



        public void AddCity(IList<City> citys)
        {
            using (SessionNoServer session = new SessionNoServer(SystemDir))
            {

                session.BeginUpdate();
                foreach (var city in citys)
                {
                    session.Persist(city);
                   
                }
                session.Commit();

            }
        }
    }
}