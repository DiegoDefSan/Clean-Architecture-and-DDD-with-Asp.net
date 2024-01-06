using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    /// <inheritdoc />
    public partial class CleanArchitectureDiego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VideosActores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "VideosActores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VideosActores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "VideosActores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "VideosActores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Videos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Streamers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Streamers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Directores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Directores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Directores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Directores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Actores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Actores",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "VideosActores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Actores");
        }
    }
}
