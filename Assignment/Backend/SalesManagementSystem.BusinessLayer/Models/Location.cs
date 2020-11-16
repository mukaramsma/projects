using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.BusinessLayer.Models
{
    public class Location
    {
        public Location()
        { }

        public Location(string country, string state, string city)
        {
            this.Country = country;
            this.State = state;
            this.City = city;
            this.Code = GetCode();
        }

        [Key]
        public string Code { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string GetCode()
        {
            var country = string.IsNullOrEmpty(Country) ? "Unknown" : Country;
            var state = string.IsNullOrEmpty(State) ? "Unknown" : State;
            var city = string.IsNullOrEmpty(City) ? "Unknown" : City;

            return $"{country}_{state}_{city}";
        }
    }
}
