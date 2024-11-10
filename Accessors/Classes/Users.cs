using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;
using Microsoft.Data.SqlClient;

namespace Accessors.Classes
{
    public class User : IUser
    {
        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public User(int userId, string firstName, string lastName, string email, string password)
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
            List<User> usersList = new List<User>();
            string query = $"SELECT * FROM Users";
            Database db = new Database();
            DataTable userData = Database.ExecuteQuery(query);

            foreach (DataRow row in userData.Rows)
            {
                User user = new User((int)row[0],
                    row[1].ToString(),
                    row[2].ToString(),
                    row[3].ToString(),
                    row[4].ToString());

                usersList.Add(user);
            }

            return usersList;
        }

        public User GetUserById(int id)
        {
            string query = $"SELECT * FROM Users WHERE UserId = {id}";
            Database db = new Database();
            DataTable userData = Database.ExecuteQuery(query);
            DataRow row = userData.Rows[0];
            User user = new User((int)row[0], 
                row[1].ToString(),
                row[2].ToString(),
                row[3].ToString(),
                row[4].ToString());
            
            return user;
        }

        public bool AddUserToDb(User user)
        {
            return false;
        }
    }
}
