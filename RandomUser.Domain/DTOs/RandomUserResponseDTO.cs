using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.DTOs {
    public class RandomUserResponseDTO {
        public required IEnumerable<UserDTO> Results { get; set; }
    }
}
