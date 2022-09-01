using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
	public partial class AddedLeaveTables : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "LeaveTypes",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
					DefaultDays = table.Column<int>(type: "int", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2(4)", nullable: false),
					DateModified = table.Column<DateTime>(type: "datetime2(4)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LeaveTypes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "LeaveAllocations",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					NumberOfDays = table.Column<int>(type: "int", nullable: false),
					LeaveTypeId = table.Column<int>(type: "int", nullable: false),
					EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
					DateCreated = table.Column<DateTime>(type: "datetime2(4)", nullable: false),
					DateModified = table.Column<DateTime>(type: "datetime2(4)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LeaveAllocations", x => x.Id);
					table.ForeignKey(
						name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
						column: x => x.LeaveTypeId,
						principalTable: "LeaveTypes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_LeaveAllocations_LeaveTypeId",
				table: "LeaveAllocations",
				column: "LeaveTypeId");

			// See: https://stackoverflow.com/questions/22618237/how-to-create-index-in-entity-framework-6-2-with-code-first

			migrationBuilder.AddUniqueConstraint(
				name: "UC_LeaveTypes_Name",
				table: "LeaveTypes",
				column: "Name");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "LeaveAllocations");

			migrationBuilder.DropTable(
				name: "LeaveTypes");
		}
	}
}
