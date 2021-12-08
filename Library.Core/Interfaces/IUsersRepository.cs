﻿using Academy.Week2.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        User? GetByEmail(string email);
    }
}
