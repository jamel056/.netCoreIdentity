using NetCoreIdentity.Data.Enum;

namespace NetCoreIdentity.Requests
{
    public class EditUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }
}
