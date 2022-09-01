using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class Employee : IdentityUser
    {
        [Column(TypeName = "varchar(256)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string TaxId { get; set; }

        [Column(TypeName = "datetime2(4)")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "datetime2(4)")]
        public DateTime DateJoined { get; set; }
    }
}
