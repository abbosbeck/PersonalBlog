using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConnectUserAndBLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "Blogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserEntityId",
                table: "Blogs",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserEntityId",
                table: "Blogs",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserEntityId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserEntityId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Blogs");
        }
    }
}
