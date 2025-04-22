namespace DTOs.Human
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Name { get; set; }
    }
}
