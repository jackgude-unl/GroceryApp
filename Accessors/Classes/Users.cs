using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;

namespace Accessors.Classes
{
    public class User : IUser
    {
        public string UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public User(string userId, string firstName, string lastName, string email, string password)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }

    public class UserAccessor : IUserAccessor
    {
        public IEnumerable<User> GetAllUsers()
        {
            return null;
        }

        public User GetUserById(int id)
        {
            return null;
        }

        public bool AddUserToDb(User user)
        {
            return false;
        }
    }
}
