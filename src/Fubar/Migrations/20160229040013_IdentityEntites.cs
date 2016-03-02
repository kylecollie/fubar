using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Fubar.Migrations
{
    public partial class IdentityEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Category_CategoryId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Priority_PriorityId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Product_ProductId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Severity_SeverityId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_User_UserId", table: "Ticket");
            migrationBuilder.DropColumn(name: "UserId", table: "Ticket");
            migrationBuilder.DropTable("User");
            migrationBuilder.CreateTable(
                name: "Resolution",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.ID);
                });
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });
            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "Ticket",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Priority_PriorityId",
                table: "Ticket",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Product_ProductId",
                table: "Ticket",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Resolution_ResolutionId",
                table: "Ticket",
                column: "ResolutionId",
                principalTable: "Resolution",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Severity_SeverityId",
                table: "Ticket",
                column: "SeverityId",
                principalTable: "Severity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Status_StatusId",
                table: "Ticket",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Category_CategoryId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Priority_PriorityId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Product_ProductId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Resolution_ResolutionId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Severity_SeverityId", table: "Ticket");
            migrationBuilder.DropForeignKey(name: "FK_Ticket_Status_StatusId", table: "Ticket");
            migrationBuilder.DropColumn(name: "ResolutionId", table: "Ticket");
            migrationBuilder.DropColumn(name: "StatusId", table: "Ticket");
            migrationBuilder.DropTable("Resolution");
            migrationBuilder.DropTable("Status");
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Category_CategoryId",
                table: "Ticket",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Priority_PriorityId",
                table: "Ticket",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Product_ProductId",
                table: "Ticket",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Severity_SeverityId",
                table: "Ticket",
                column: "SeverityId",
                principalTable: "Severity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_User_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
