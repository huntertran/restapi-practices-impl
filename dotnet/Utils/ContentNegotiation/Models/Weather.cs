using System;

namespace sampleApi.Utils.ContentNegotiation.Models
{
    public class Weather
    {
        private DateTime _date;
        private double _temperature;

        public Weather(DateTime date, double temperature)
        {
            this._date = date;
            this._temperature = temperature;
        }

        public Weather() { }

        public DateTime Date { get; set; }
        public double Temperature { get; set; }
    }
}