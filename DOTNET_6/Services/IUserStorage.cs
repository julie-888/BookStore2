using DOTNET_6.Models;

namespace DOTNET_6.Services
{
    public interface IUserStorage
    {
        User AddNewUser(string name);
        List<User> GetUsers();
        User GetUserByName(string name);
        
    }

    public class UserStorage : IUserStorage
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Name = "Gamabuta",
                BooksToRefund = new List<Book>()
            }
        };

        public User AddNewUser(string name)
        {
            User newUser = new User()
            {
                Name = name
            };
            Users.Add(newUser);
            return newUser;
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public User GetUserByName(string name)
        {
            return Users.FirstOrDefault(f => f.Name == name);
        }
    }
}
