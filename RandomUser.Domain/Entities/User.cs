using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Entities {
    public class User {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string NameTitle { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Email { get; set; }
        public DateTime DobDate { get; set; }
        public int DobAge { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int RegisteredAge { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string IdName { get; set; }
        public string IdValue { get; set; }
        public string Nat { get; set; }
        public UserLocation Location { get; set; }
        public UserLogin Login { get; set; }
        public UserPicture Picture { get; set; }
    }
}
