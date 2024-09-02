namespace NorthwindBasedWebApplication.Models.Dtos.AuthenticationDtos
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
