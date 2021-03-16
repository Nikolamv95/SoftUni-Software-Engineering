﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class ICollectionChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "ClientProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "ClientProducts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Orders_OrderId",
                table: "ClientProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
