using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Entities {
    public class UserLocation {
        public int UserId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string CoordinatesLatitude { get; set; }
        public string CoordinatesLongitude { get; set; }
        public string TimezoneOffset { get; set; }
        public string TimezoneDescription { get; set; }
    }
}
