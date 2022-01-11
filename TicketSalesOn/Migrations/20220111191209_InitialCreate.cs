using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesOn.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieChairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameChair = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieChairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMovie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PremiereDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheatres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameNetwork = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheatres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieTheatreId = table.Column<int>(type: "int", nullable: true),
                    MovieChairId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_MovieChairs_MovieChairId",
                        column: x => x.MovieChairId,
                        principalTable: "MovieChairs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_MovieTheatres_MovieTheatreId",
                        column: x => x.MovieTheatreId,
                        principalTable: "MovieTheatres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoviesTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedules = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moviesId = table.Column<int>(type: "int", nullable: true),
                    roomsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesTimes_Movies_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MoviesTimes_Rooms_roomsId",
                        column: x => x.roomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    RoomsId = table.Column<int>(type: "int", nullable: true),
                    MovieTimesId = table.Column<int>(type: "int", nullable: true),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_MoviesTimes_MovieTimesId",
                        column: x => x.MovieTimesId,
                        principalTable: "MoviesTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesTimes_moviesId",
                table: "MoviesTimes",
                column: "moviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesTimes_roomsId",
                table: "MoviesTimes",
                column: "roomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MovieChairId",
                table: "Rooms",
                column: "MovieChairId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MovieTheatreId",
                table: "Rooms",
                column: "MovieTheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_MovieTimesId",
                table: "ShoppingCarts",
                column: "MovieTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_RoomsId",
                table: "ShoppingCarts",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UsersId",
                table: "ShoppingCarts",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "MoviesTimes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "MovieChairs");

            migrationBuilder.DropTable(
                name: "MovieTheatres");
        }
    }
}
