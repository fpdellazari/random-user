using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Services {
    public interface IGenerateUserService {
        Task GenerateUser();
    }
}
