using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitizenData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Deceased = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressLine = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressLine);
                    table.ForeignKey(
                        name: "FK_Address_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    DateType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.DateType);
                    table.ForeignKey(
                        name: "FK_Date_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.FirstName);
                    table.ForeignKey(
                        name: "FK_Name_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EntityId",
                table: "Address",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Date_EntityId",
                table: "Date",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Name_EntityId",
                table: "Name",
                column: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
