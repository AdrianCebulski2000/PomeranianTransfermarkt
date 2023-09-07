using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomeranianTransfermarkt.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketValue = table.Column<double>(type: "float", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "ClubsPlayers",
                columns: table => new
                {
                    ClubsClubId = table.Column<int>(type: "int", nullable: false),
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsPlayers", x => new { x.ClubsClubId, x.PlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_ClubsPlayers_Clubs_ClubsClubId",
                        column: x => x.ClubsClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubsPlayers_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClubsTrainers",
                columns: table => new
                {
                    ClubsClubId = table.Column<int>(type: "int", nullable: false),
                    TrainersTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsTrainers", x => new { x.ClubsClubId, x.TrainersTrainerId });
                    table.ForeignKey(
                        name: "FK_ClubsTrainers_Clubs_ClubsClubId",
                        column: x => x.ClubsClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubsTrainers_Trainers_TrainersTrainerId",
                        column: x => x.TrainersTrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayersTrainers",
                columns: table => new
                {
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false),
                    TrainersTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTrainers", x => new { x.PlayersPlayerId, x.TrainersTrainerId });
                    table.ForeignKey(
                        name: "FK_PlayersTrainers_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersTrainers_Trainers_TrainersTrainerId",
                        column: x => x.TrainersTrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubsPlayers_PlayersPlayerId",
                table: "ClubsPlayers",
                column: "PlayersPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsTrainers_TrainersTrainerId",
                table: "ClubsTrainers",
                column: "TrainersTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTrainers_TrainersTrainerId",
                table: "PlayersTrainers",
                column: "TrainersTrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubsPlayers");

            migrationBuilder.DropTable(
                name: "ClubsTrainers");

            migrationBuilder.DropTable(
                name: "PlayersTrainers");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
