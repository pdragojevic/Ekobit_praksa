using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions.Interfaces
{
    public interface IUser_Operations
    {
        Task<List<Entities.User>> ReadAllUsers();
        Entities.User ReadUser(string user_name);
    }
}
