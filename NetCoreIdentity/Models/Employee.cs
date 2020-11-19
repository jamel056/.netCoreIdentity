using NetCoreIdentity.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreIdentity.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Position Position { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
