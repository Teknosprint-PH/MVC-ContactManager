using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_challenge.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_contacts",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contact_firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contact_middlename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contact_address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    contact_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    contact_status = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contacts", x => x.contact_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_contacts");
        }
    }
}
