﻿using System;
using System.Collections.Generic;
using CitiesApiNet.Models;

namespace CitiesApiNet.data
{
    public interface IRepositoryCity : IDisposable
    {
        List<City> Cities();
        List<City> Cities(string countryCode);
        City City(double latitude,double longitute);
        City City(string name);
    }
}

