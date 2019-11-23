using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public Address()
        {

        }
        static Address()
        {

        }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
