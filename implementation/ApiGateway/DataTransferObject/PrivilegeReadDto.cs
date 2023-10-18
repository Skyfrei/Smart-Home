namespace ApiGateway.Dto
{
    public class PrivilegeReadDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role UserRole { get; set; }

        public string Email { get; set; }
    }
}