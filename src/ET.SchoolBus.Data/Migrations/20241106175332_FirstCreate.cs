using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ET.SchoolBus.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                });

            migrationBuilder.CreateTable(
                name: "Hostesses",
                columns: table => new
                {
                    HostesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostesses", x => x.HostesId);
                    table.ForeignKey(
                        name: "FK_Hostesses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parents_Professions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId");
                    table.ForeignKey(
                        name: "FK_Parents_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    Plaque = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Hostesses_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Hostesses",
                        principalColumn: "HostesId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId");
                    table.ForeignKey(
                        name: "FK_Vehicles_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drives_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_Drives_Vehicles_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_Students_Vehicles_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => new { x.StudentId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId");
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drives_SchoolId",
                table: "Drives",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Hostesses_SchoolId",
                table: "Hostesses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_SchoolId",
                table: "Parents",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_ParentId",
                table: "StudentParents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicles",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SchoolId",
                table: "Vehicles",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Hostesses");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
