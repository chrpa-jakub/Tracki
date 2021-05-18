using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountTypes",
                columns: table => new
                {
                    typeID = table.Column<int>(type: "integer", nullable: false),
                    typeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("accountTypes_pkey", x => x.typeID);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    photoID = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.photoID);
                });

            migrationBuilder.CreateTable(
                name: "releaseTypes",
                columns: table => new
                {
                    releaseTypeID = table.Column<int>(type: "integer", nullable: false),
                    releaseTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_releaseTypes", x => x.releaseTypeID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'', '1', '0', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userName = table.Column<string>(type: "text", nullable: true),
                    accountTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    passwordHash = table.Column<string>(type: "text", nullable: true),
                    photoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_accountTypeID",
                        column: x => x.accountTypeID,
                        principalTable: "accountTypes",
                        principalColumn: "typeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotoIDUser",
                        column: x => x.photoID,
                        principalTable: "photos",
                        principalColumn: "photoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "integer", nullable: false),
                    artistName = table.Column<string>(type: "text", nullable: true),
                    artistLocation = table.Column<string>(type: "text", nullable: true),
                    userID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.artistID);
                    table.ForeignKey(
                        name: "FK_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "releases",
                columns: table => new
                {
                    releaseID = table.Column<int>(type: "integer", nullable: false),
                    albumName = table.Column<string>(type: "text", nullable: false),
                    artistID = table.Column<int>(type: "integer", nullable: false),
                    yearOfRelease = table.Column<int>(type: "integer", nullable: false),
                    releaseTypeID = table.Column<int>(type: "integer", nullable: false),
                    photoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_releases", x => x.releaseID);
                    table.ForeignKey(
                        name: "FK_artistID",
                        column: x => x.artistID,
                        principalTable: "artists",
                        principalColumn: "artistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_PhotoIDRelease",
                        column: x => x.photoID,
                        principalTable: "photos",
                        principalColumn: "photoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_releaseTypeID",
                        column: x => x.releaseTypeID,
                        principalTable: "releaseTypes",
                        principalColumn: "releaseTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    songID = table.Column<int>(type: "integer", nullable: false),
                    songName = table.Column<string>(type: "text", nullable: false),
                    releaseID = table.Column<int>(type: "integer", nullable: false),
                    songLocation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.songID);
                    table.ForeignKey(
                        name: "FK_releaseID",
                        column: x => x.releaseID,
                        principalTable: "releases",
                        principalColumn: "releaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fki_FK_userID",
                table: "artists",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "fki_FK_artistID",
                table: "releases",
                column: "artistID");

            migrationBuilder.CreateIndex(
                name: "fki_Fk_PhotoIDRelease",
                table: "releases",
                column: "photoID");

            migrationBuilder.CreateIndex(
                name: "fki_FK_releaseTypeID",
                table: "releases",
                column: "releaseTypeID");

            migrationBuilder.CreateIndex(
                name: "fki_FK_albumID",
                table: "songs",
                column: "releaseID");

            migrationBuilder.CreateIndex(
                name: "fki_FK_accountTypeID",
                table: "users",
                column: "accountTypeID");

            migrationBuilder.CreateIndex(
                name: "fki_FK_PhotoIDUser",
                table: "users",
                column: "photoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "releases");

            migrationBuilder.DropTable(
                name: "artists");

            migrationBuilder.DropTable(
                name: "releaseTypes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "accountTypes");

            migrationBuilder.DropTable(
                name: "photos");
        }
    }
}
