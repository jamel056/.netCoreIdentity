using NetCoreIdentity.Models;

namespace NetCoreIdentity.DTO
{
    public class UserDTO
    {
        public UserDTO(ApplicationUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            Sex = user.Sex.ToString();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
