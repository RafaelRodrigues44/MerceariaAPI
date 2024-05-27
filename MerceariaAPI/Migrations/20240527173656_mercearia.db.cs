using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerceariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class merceariadb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biscoito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biscoito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cereal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cereal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Higiene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Higiene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hortifruti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hortifruti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laticinio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laticinio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Limpeza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limpeza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Padaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papelaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papelaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utensilios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utensilios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropTable(
                name: "Biscoito");

            migrationBuilder.DropTable(
                name: "Carne");

            migrationBuilder.DropTable(
                name: "Cereal");

            migrationBuilder.DropTable(
                name: "Doce");

            migrationBuilder.DropTable(
                name: "Frios");

            migrationBuilder.DropTable(
                name: "Geral");

            migrationBuilder.DropTable(
                name: "Higiene");

            migrationBuilder.DropTable(
                name: "Hortifruti");

            migrationBuilder.DropTable(
                name: "Laticinio");

            migrationBuilder.DropTable(
                name: "Limpeza");

            migrationBuilder.DropTable(
                name: "Padaria");

            migrationBuilder.DropTable(
                name: "Papelaria");

            migrationBuilder.DropTable(
                name: "Utensilios");
        }
    }
}
