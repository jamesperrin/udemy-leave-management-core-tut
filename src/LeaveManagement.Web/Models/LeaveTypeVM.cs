using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Display(Name = "Default Number of Days")]
        [Required]
        [Range(1, 25, ErrorMessage = "Please enter a number between {1} and {2}.")]
        public int DefaultDays { get; set; }
    }
}
