using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInfo
{
    public class Employee
    {
        public string Gin
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double BodyTemperature
        {
            get;
            set;
        }
        public bool HubeiTravelStatus
        {
            get;
            set;
        }
        public bool UnderTheWeather
        {
            get;
            set;
        }
        public DateTime RecordDate
        {
            get;
            set;
        }
        public Employee(string gin, string name, double bodyTemperature, bool hubeiTravelStatus, bool underTheWeather, DateTime recordDate)
        {
            Gin = gin;
            Name = name;
            BodyTemperature = bodyTemperature;
            HubeiTravelStatus = hubeiTravelStatus;
            UnderTheWeather = underTheWeather;
            RecordDate = recordDate;
        }
        public bool Alert()
        {
            if ( BodyTemperature >= 37.3 || HubeiTravelStatus || UnderTheWeather )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Gin:" + Gin + "," + "Name:" + Name;
        }
    }
}
