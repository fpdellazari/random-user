using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.DTOs {
    public class AuthenticateRequestDTO {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
