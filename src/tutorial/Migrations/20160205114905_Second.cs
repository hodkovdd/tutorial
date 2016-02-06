using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace tutorial.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Order_Phone_PhoneId", table: "Order");
            migrationBuilder.AddForeignKey(
                name: "FK_Order_Phone_PhoneId",
                table: "Order",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Order_Phone_PhoneId", table: "Order");
            migrationBuilder.AddForeignKey(
                name: "FK_Order_Phone_PhoneId",
                table: "Order",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
