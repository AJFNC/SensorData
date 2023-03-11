using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SensorData.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sensor_Id = table.Column<int>(type: "integer", nullable: false),
                    Frl1 = table.Column<float>(type: "real", nullable: false),
                    Frl2 = table.Column<float>(type: "real", nullable: false),
                    Frl3 = table.Column<float>(type: "real", nullable: false),
                    ReadDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ar1 = table.Column<int>(type: "integer", nullable: false),
                    Ar2 = table.Column<int>(type: "integer", nullable: false),
                    Ar3 = table.Column<int>(type: "integer", nullable: false),
                    H2o1 = table.Column<int>(type: "integer", nullable: false),
                    H2o2 = table.Column<int>(type: "integer", nullable: false),
                    H2o3 = table.Column<int>(type: "integer", nullable: false),
                    CalDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Lat = table.Column<string>(type: "text", nullable: true),
                    Long = table.Column<string>(type: "text", nullable: true),
                    A = table.Column<float>(type: "real", nullable: true),
                    B = table.Column<float>(type: "real", nullable: true),
                    R2 = table.Column<float>(type: "real", nullable: true),
                    Sensor_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Spots");
        }
    }
}
