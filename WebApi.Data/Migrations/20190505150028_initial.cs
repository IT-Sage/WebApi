using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ImgUri = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("841796d4-80b8-484a-9a66-7bccd0c4f296"), "Speed of transfer up to 200MB/s", "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SASC022i1&i=1.jpg", "USB Flash Disk", 299m },
                    { new Guid("2136eaad-4d96-435c-abcc-7a3b549cfcdd"), null, "https://cdn.alza.cz/ImgW.ashx?fd=FotoAddOrig&cd=MC001b1-02&i=1.jpg", "Keyboard", 390m },
                    { new Guid("271ff3fa-6952-4d54-ab57-b525f4fbd66b"), "Battery life up to 9 months", "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=ME362d2&i=1.jpg", "Mouse", 599m },
                    { new Guid("eefbcc21-72fd-41a0-a4c9-132f1acec395"), null, "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=NA626d65&i=1.jpg", "Notebook", 31990m },
                    { new Guid("74f5110e-fdc7-4137-b064-bafadc64b43a"), null, "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SAMO0163b3&i=1.jpg", "Mobile Phone", 6999m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
