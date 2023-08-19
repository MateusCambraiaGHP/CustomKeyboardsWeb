using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomKeyboardsWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class M_AddInsertEntityAndLastModifyOnSave_M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Switch");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Switch",
                newName: "LastModification");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Supplier",
                newName: "LastModification");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Member",
                newName: "LastModification");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Keyboard",
                newName: "LastModification");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Key",
                newName: "LastModification");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Customer",
                newName: "LastModification");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Switch",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Supplier",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Member",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Keyboard",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Key",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertionDate",
                table: "Customer",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Switch");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Keyboard");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Key");

            migrationBuilder.DropColumn(
                name: "InsertionDate",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Switch",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Supplier",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Member",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Keyboard",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Key",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastModification",
                table: "Customer",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Switch",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Supplier",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Member",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Keyboard",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Key",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customer",
                type: "datetime",
                nullable: true);
        }
    }
}
