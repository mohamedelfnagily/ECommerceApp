using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.DAL.Migrations
{
    public partial class CreatingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values:new object[] {Guid.NewGuid(),"Automotive", "Automotive" }
                    
                );

            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Electronics", "Electronics" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Computers", "Computers" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Smart Home", "Smart Home" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Arts & Crafts", "Arts & Crafts" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Baby", "Baby" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Women's Fashion", "Women's Fashion" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Men's Fashion", "Men's Fashion" }

                );
            migrationBuilder.InsertData(
        table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Girl's Fashion", "Girl's Fashion" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Boy's Fashion", "Boy's Fashion" }

                );
            migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Id", "Name", "Description" },
                    values: new object[] { Guid.NewGuid(), "Health and Household", "Health and Household" }

                );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Home and Kitchen", "Home and Kitchen" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Industrial and Scientific", "Industrial and Scientific" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Luggage", "Luggage" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Pet Supplies", "Pet Supplies" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Software", "Software" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Sports and Outdoors", "Sports and Outdoors" }

            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[] { Guid.NewGuid(), "Video Games", "Video Games" }

            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
