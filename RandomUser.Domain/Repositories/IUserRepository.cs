using RandomUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Repositories {
    public interface IUserRepository {

        IEnumerable<User> Get();
        User Get(int id);
        void Insert(User user);
        void Update(User user);
    }
}
