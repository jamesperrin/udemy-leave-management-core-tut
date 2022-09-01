using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
	public class LeaveType : BaseEntity
	{
		[Column(TypeName = "varchar(256)")]
		[MaxLength(length: 256)]
		public string Name { get; set; }

		public int DefaultDays { get; set; }
	}
}
