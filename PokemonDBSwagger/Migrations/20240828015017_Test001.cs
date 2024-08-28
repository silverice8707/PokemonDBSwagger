using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonDBSwagger.Migrations
{
    /// <inheritdoc />
    public partial class Test001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    againstNormal = table.Column<byte>(type: "tinyint", nullable: false),
                    againstFire = table.Column<byte>(type: "tinyint", nullable: false),
                    againstWater = table.Column<byte>(type: "tinyint", nullable: false),
                    againstGrass = table.Column<byte>(type: "tinyint", nullable: false),
                    againstElectric = table.Column<byte>(type: "tinyint", nullable: false),
                    againstIce = table.Column<byte>(type: "tinyint", nullable: false),
                    againstFighting = table.Column<byte>(type: "tinyint", nullable: false),
                    againstPoison = table.Column<byte>(type: "tinyint", nullable: false),
                    againstGround = table.Column<byte>(type: "tinyint", nullable: false),
                    againstFlying = table.Column<byte>(type: "tinyint", nullable: false),
                    againstPsychic = table.Column<byte>(type: "tinyint", nullable: false),
                    againstBug = table.Column<byte>(type: "tinyint", nullable: false),
                    againstRock = table.Column<byte>(type: "tinyint", nullable: false),
                    againstGhost = table.Column<byte>(type: "tinyint", nullable: false),
                    againstDark = table.Column<byte>(type: "tinyint", nullable: false),
                    againstDragon = table.Column<byte>(type: "tinyint", nullable: false),
                    againstSteel = table.Column<byte>(type: "tinyint", nullable: false),
                    againstFairy = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokedexNumber = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PokemonName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PokemonTitle = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TypeAId = table.Column<int>(type: "int", nullable: false),
                    TypeBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_TypeAId",
                        column: x => x.TypeAId,
                        principalTable: "PokemonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_TypeBId",
                        column: x => x.TypeBId,
                        principalTable: "PokemonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TypeAId",
                table: "Pokemons",
                column: "TypeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TypeBId",
                table: "Pokemons",
                column: "TypeBId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "PokemonTypes");
        }
    }
}
