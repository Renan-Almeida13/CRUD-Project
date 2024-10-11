using Domain.Commons;

namespace Domain.Entities.User
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
    }
}
