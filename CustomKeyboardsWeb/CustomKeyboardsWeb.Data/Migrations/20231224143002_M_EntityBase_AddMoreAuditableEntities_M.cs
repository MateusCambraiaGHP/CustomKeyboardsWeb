using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomKeyboardsWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class M_EntityBase_AddMoreAuditableEntities_M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Switch",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Switch",
                newName: "InsertionBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Supplier",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Supplier",
                newName: "InsertionBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Member",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Member",
                newName: "InsertionBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Keyboard",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Keyboard",
                newName: "InsertionBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Key",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Key",
                newName: "InsertionBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Customer",
                newName: "ModificationBy");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Customer",
                newName: "InsertionBy");

            migrationBuilder.AddColumn<string>(
                name: "InsertionBy",
                table: "PuchaseHistory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ModificationBy",
                table: "PuchaseHistory",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Member",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertionBy",
                table: "PuchaseHistory");

            migrationBuilder.DropColumn(
                name: "ModificationBy",
                table: "PuchaseHistory");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Switch",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Switch",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Supplier",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Supplier",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Member",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Member",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Keyboard",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Keyboard",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Key",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Key",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "ModificationBy",
                table: "Customer",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "InsertionBy",
                table: "Customer",
                newName: "CreatedBy");
        }
    }
}
