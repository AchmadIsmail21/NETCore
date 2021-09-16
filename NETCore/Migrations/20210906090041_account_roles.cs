using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class account_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "tb_m_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_role", x => x.Id);
                });

           
            migrationBuilder.CreateTable(
                name: "tb_n_AccountRole",
                columns: table => new
                {
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_n_AccountRole", x => new { x.AccountNIK, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tb_n_AccountRole_tb_m_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_n_AccountRole_tb_tr_accounts_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "tb_tr_accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_tb_n_AccountRole_RoleId",
                table: "tb_n_AccountRole",
                column: "RoleId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_n_AccountRole");

            migrationBuilder.DropTable(
                name: "tb_tr_profiling");

            migrationBuilder.DropTable(
                name: "tb_m_role");

            migrationBuilder.DropTable(
                name: "tb_m_educations");

            migrationBuilder.DropTable(
                name: "tb_tr_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_university");

            migrationBuilder.DropTable(
                name: "tb_m_persons");
        }
    }
}
