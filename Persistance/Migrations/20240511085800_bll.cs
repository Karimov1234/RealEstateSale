using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class bll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Products_ProductId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_HomeOwner_HomeOwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Images_AdvertisementId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "HomeOwnerId",
                table: "Products",
                newName: "HomeOwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_HomeOwnerId",
                table: "Products",
                newName: "IX_Products_HomeOwnerID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Images",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductID",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "HomeOwnerID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishTimeImage",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Products_ProductId",
                table: "Advertisements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HomeOwner_HomeOwnerID",
                table: "Products",
                column: "HomeOwnerID",
                principalTable: "HomeOwner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Products_ProductId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_HomeOwner_HomeOwnerID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublishTimeImage",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "HomeOwnerID",
                table: "Products",
                newName: "HomeOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_HomeOwnerID",
                table: "Products",
                newName: "IX_Products_HomeOwnerId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Images",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                newName: "IX_Images_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "HomeOwnerId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdvertisementId",
                table: "Images",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Agents_AgentId",
                table: "Advertisements",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Products_ProductId",
                table: "Advertisements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductID",
                table: "Images",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_HomeOwner_HomeOwnerId",
                table: "Products",
                column: "HomeOwnerId",
                principalTable: "HomeOwner",
                principalColumn: "Id");
        }
    }
}
