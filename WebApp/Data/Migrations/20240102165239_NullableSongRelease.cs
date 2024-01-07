﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectMPD.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableSongRelease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Releases_ReleaseID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Releases_ReleaseID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseID",
                table: "Songs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseID",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Releases_ReleaseID",
                table: "Reviews",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Releases_ReleaseID",
                table: "Songs",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Releases_ReleaseID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Releases_ReleaseID",
                table: "Songs");

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseID",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReleaseID",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Releases_ReleaseID",
                table: "Reviews",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Releases_ReleaseID",
                table: "Songs",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
