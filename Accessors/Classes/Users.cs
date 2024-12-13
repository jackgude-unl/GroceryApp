using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
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

        public User(string firstName, string lastName, string email, int userId = 0)
        {
            UserId = (userId == 0) ? GetNextFreeUserId() : userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
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
        private const int HashSize = 100;
        private const int SaltSize = 32;
        private const int Iterations = 100;

        public User? VerifyUser(string email, string password)
        {
            const string query = "SELECT * FROM Users WHERE eMail = @email";

            var parameters = new List<SqlParameter>
            {
                new("@email", email)
            };

            var userData = DatabaseAccessor.ExecuteQuery(query, parameters);
            var row = userData.Rows[0];
            var user = new User((string)row[1],
                (string)row[2],
                (string)row[3],
                (int)row[0]);
            var hash = (byte[])row[4];
            var salt = (byte[])row[5];

            var newHash = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256).GetBytes(HashSize);

            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != newHash[i]) return null;
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            const string query = "SELECT * FROM Users";
            var userData = DatabaseAccessor.ExecuteQuery(query);

            var usersList = new List<User>();
            foreach (DataRow row in userData.Rows)
            {
                var user = new User((string)row[1],
                    (string)row[2],
                    (string)row[3],
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
            var user = new User((string)row[1],
                (string)row[2],
                (string)row[3],
                (int)row[0]);

            return user;
        }

        public bool AddUserToDb(User user, string password)
        {
            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hash = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);

            const string query = "INSERT INTO Users (FirstName, LastName, Email, PasswordHash, PasswordSalt)" +
                                 "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt)";

            var parameters = new List<SqlParameter>
            {
                new("@FirstName", user.FirstName),
                new("@LastName", user.LastName),
                new("@Email", user.Email),
                new("@PasswordHash", hash.GetBytes(HashSize)),
                new("@PasswordSalt", salt)
            };

            var rows = DatabaseAccessor.ExecuteNonQuery(query, parameters);

            return (rows == 1);
        }
    }
}
