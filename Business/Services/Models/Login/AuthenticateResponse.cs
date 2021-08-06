using Business.Services.Models.User;

namespace Business.Services.Models.Login
{
    public class AuthenticateResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(UserDto user, string token)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            Password = user.Password;
            LastName = user.LastName;
            ZipCode = user.ZipCode;
            CityName = user.CityName;
            Token = token;
        }
    }
}
