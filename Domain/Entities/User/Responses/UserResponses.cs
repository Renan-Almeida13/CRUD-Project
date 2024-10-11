namespace Domain.Entities.User.Responses
{
    public class UserResponses { }
    public class UserListResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
    }
    public class UserGetResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? DateChange { get; set; }
    }
    public class UserGetByIdResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string ProfileName { get; set; }
    }
}
