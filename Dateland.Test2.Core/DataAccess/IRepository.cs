using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dateland.Test2.Core
{
    public interface IRepository
    {
        abstract Task<IEnumerable<User>> GetUsers();

        abstract Task AddUser(User user);

    }
}
