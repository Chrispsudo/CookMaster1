namespace CookMaster1.Models
{
    public class User
    {
        // Users chosen username 
        public string Username { get; set; }

        // Simple password without hashing for demonstration purposes
        public string Password { get; set; }

        // User's country
        public string Country { get; set; }

        // Checking if password matches
        public bool ValidateLogin(string pw) => Password == pw;

        // Changing user's password
        public void ChangePassword(string newPw)
        {
            Password = newPw;
        }

        // Updating user's information
        public void UpdateDetails(string username, string country)
        {
            Username = username;

            Country = country;
        }

    }
}
