using CookMaster1.Models;
using System.Collections.Generic;
using System.Linq;

namespace CookMaster1.Services
{
    public class UserManager
    {
        // List of all users

        public List<User> Users { get; set; } = new List<User>();

        // Currently logged in user
        public User LoggedIn { get; set; }

        // Try logging in with username and password

        public bool Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.ValidateLogin(password))
            {
                LoggedIn = user;
                return true;
            }
            return false;
        }

        // Register a new user

        public bool Register(string username, string password, string country)
        {
            if (Users.Any(u => u.Username == username))
            {
                return false; // Username already exists
            }

            // Create new user and add to the list
            var newUser = new User
            {
                Username = username,
                Password = password,
                Country = country
            };
            Users.Add(newUser);
            return true;
        }

        // Give the user logged in

        public User GetLoggedIn() => LoggedIn;


    }
}
