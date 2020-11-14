using NetCoreIdentity.Data.Enum;
using NetCoreIdentity.Models;

namespace NetCoreIdentity.Requests
{
    public class ApplicationUserRequest
    {
        public ApplicationUser GetModel()
        {
            return new ApplicationUser()
            {
                UserName = UserName,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Sex = Sex
            };
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }
}
