using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_challenge.Migrations
{
    /// <inheritdoc />
    public partial class AddContact_InfoIdentityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_contacts",
                keyColumn: "contact_id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2024, 6, 23, 22, 13, 26, 32, DateTimeKind.Local).AddTicks(6063));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_contacts",
                keyColumn: "contact_id",
                keyValue: 1,
                column: "created_dt",
                value: new DateTime(2024, 6, 23, 0, 9, 3, 535, DateTimeKind.Local).AddTicks(6385));
        }
    }
}
