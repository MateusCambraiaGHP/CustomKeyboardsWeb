using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomKeyboardsWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class M_Entity_AddAuditableEntity_M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Switch",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Switch",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Supplier",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Supplier",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "PuchaseHistory",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PuchaseHistory",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Member",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Member",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Keyboard",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Keyboard",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Key",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Key",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Customer",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customer",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Switch");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Switch");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "PuchaseHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PuchaseHistory");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customer");
        }
    }
}
