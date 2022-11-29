using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestePratico.Data.Migrations
{
    public partial class Addtimestamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UFs",
                type: "TIMESTAMP",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UFs",
                type: "TIMESTAMP",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "People",
                type: "TIMESTAMP",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "People",
                type: "TIMESTAMP",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UFs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UFs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "People");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "People");
        }
    }
}
