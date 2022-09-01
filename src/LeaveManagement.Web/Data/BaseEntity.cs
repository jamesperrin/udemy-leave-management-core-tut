using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }

		[Column(TypeName = "datetime2(4)")]
		public DateTime DateCreated { get; set; }

		[Column(TypeName = "datetime2(4)")]
		public DateTime DateModified { get; set; }
	}
}
