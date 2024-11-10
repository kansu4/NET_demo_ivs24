﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET_demo_ivs24.Migrations
{
    /// <inheritdoc />
    public partial class addNote_col : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Items",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Items");
        }
    }
}