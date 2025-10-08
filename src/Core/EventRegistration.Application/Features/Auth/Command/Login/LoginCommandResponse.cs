namespace EventRegistration.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }

    }
}
