using NetCoreIdentity.Data.Enum;
using System;

namespace NetCoreIdentity.Requests
{
    public class AddEmployeeRequest
    {
        public string UserId { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
