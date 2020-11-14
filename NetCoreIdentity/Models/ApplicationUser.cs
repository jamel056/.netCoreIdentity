using Microsoft.AspNetCore.Identity;
using NetCoreIdentity.Data.Enum;

namespace NetCoreIdentity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }
}
