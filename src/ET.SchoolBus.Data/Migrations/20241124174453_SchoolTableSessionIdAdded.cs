using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ET.SchoolBus.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchoolTableSessionIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StudentCount",
                table: "Schools",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "StartYear",
                table: "Schools",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Schools",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SeasonId",
                table: "Schools",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Seasons_SeasonId",
                table: "Schools",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Seasons_SeasonId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_SeasonId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Schools");

            migrationBuilder.AlterColumn<int>(
                name: "StudentCount",
                table: "Schools",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<int>(
                name: "StartYear",
                table: "Schools",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolName",
                table: "Schools",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);
        }
    }
}
