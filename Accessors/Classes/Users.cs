using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace Accessors.Classes
{
    public class User : IUser
    {
        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public User(string firstName, string lastName, string email, string password, int userId = 0)
        {
            UserId = (userId == 0) ? GetNextFreeUserId() : userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static int GetNextFreeUserId()
        {
            const string query = "SELECT COUNT(UserID) from Users";

            var count = DatabaseAccessor.ExecuteQuery(query);

            return (int)count.Rows[0][0] + 1;
        }
    }

    public class UserAccessor : IUserAccessor
    {
        public IEnumerable<User> GetAllUsers()
        {
            const string query = "SELECT * FROM Users";
            var userData = DatabaseAccessor.ExecuteQuery(query);

            var usersList = new List<User>();
            foreach (DataRow row in userData.Rows)
            {
                var user = new User(row[1].ToString()!,
                    row[2].ToString()!,
                    row[3].ToString()!,
                    row[4].ToString()!,
                    (int)row[0]);

                usersList.Add(user);
            }

            return usersList;
        }

        public User GetUserById(int id)
        {
            const string query = "SELECT * FROM Users WHERE UserId = @Id";

            var parameters = new List<SqlParameter>
            {
                new("@Id", id)
            };

            var userData = DatabaseAccessor.ExecuteQuery(query, parameters);
            var row = userData.Rows[0];
            var user = new User(row[1].ToString()!,
                row[2].ToString()!,
                row[3].ToString()!,
                row[4].ToString()!,
                (int)row[0]);
            
            return user;
        }

        public bool AddUserToDb(User user)
        {
            const string query = "INSERT INTO Users (FirstName, LastName, Email, UserPassword)" + 
                                 "VALUES (@FirstName, @LastName, @Email, @UserPassword)";

            var parameters = new List<SqlParameter>
            {
                new("@FirstName", user.FirstName),
                new("@LastName", user.LastName),
                new("@Email", user.Email),
                new("@UserPassword", user.Password)
            };

            var rows = DatabaseAccessor.ExecuteNonQuery(query, parameters);

            return (rows == 1);
        }
    }
}
