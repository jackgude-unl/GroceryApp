using Accessors.Classes;
using Accessors.Interfaces;
using Microsoft.Identity.Client;

public class Program
{
    private static void Main(string[] args)
    {
        PrintUsers();
    }

    public static void PrintUsers()
    {
        UserAccessor accessor = new UserAccessor();

        IEnumerable<User> users = accessor.GetAllUsers();
        Console.WriteLine(users.GetType());
        foreach (User u in users)
        {
            Console.WriteLine(string.Concat(u.FirstName, " ", u.LastName));
        }
    }

    public static void PrintUser(int id)
    {
        UserAccessor accessor = new UserAccessor();

        User u = accessor.GetUserById(id);

        Console.WriteLine(string.Concat(u.FirstName, " ", u.LastName));
    }
}