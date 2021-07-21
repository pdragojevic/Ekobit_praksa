using Data.DataContext;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions.Specific
{
    public class User_Operations : IUser_Operations
    {
        public async Task<List<Entities.User>> ReadAllUsers()
        {
            try
            {
                using (LoginDBContext context = new LoginDBContext(LoginDBContext.Options.DatabaseOptions))
                {
                    List<Entities.User> users = await context.Users.Include(c => c.City).ToListAsync();
                    return users;
                }
            }
            catch
            {
                throw;
            }
        }

        public Entities.User ReadUser(string user_name)
        {
            try
            {
                using (LoginDBContext context = new LoginDBContext(LoginDBContext.Options.DatabaseOptions))
                {
                    Entities.User user = context.Users.Include(c => c.City).FirstOrDefault(u => u.UserName == user_name);
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
