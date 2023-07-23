using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class up_Re : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Permanence_ClinicId",
                table: "Permanence",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permanence_Clinics_ClinicId",
                table: "Permanence",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permanence_Clinics_ClinicId",
                table: "Permanence");

            migrationBuilder.DropIndex(
                name: "IX_Permanence_ClinicId",
                table: "Permanence");
        }
    }
}
