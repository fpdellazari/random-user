﻿using RandomUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Domain.Repositories {
    public interface IUserRepository {
        void Insert(User user);
    }
}
