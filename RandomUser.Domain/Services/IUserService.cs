using RandomUser.Domain.DTOs;
using RandomUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Services {
    public interface IUserService {
        IEnumerable<UserDTO> GetUserDTO();
        IEnumerable<User> Get();
        User Get(int id);
        void Update(User user);
    }
}
