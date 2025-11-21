namespace CookMaster1.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }


        public bool ValidateLogin(string pw) => Password == pw;

        public void ChangePassword(string newPw)
        {
            Password = newPw;
        }

        public void UpdateDetails(string username, string country)
        {
            Username = username;

            Country = country;
        }

    }
}
