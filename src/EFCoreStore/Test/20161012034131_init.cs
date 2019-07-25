//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace EFCoreStore.Migrations
//{
//    public partial class init : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Photograph",
//                columns: table => new
//                {
//                    PhotoId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    ThumbnailBits = table.Column<byte[]>(nullable: true),
//                    Title = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Photograph", x => x.PhotoId);
//                });

//            migrationBuilder.CreateTable(
//                name: "PhotographFullImage",
//                columns: table => new
//                {
//                    PhotoId = table.Column<int>(nullable: false),
//                    HighResolutionBits = table.Column<byte[]>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_PhotographFullImage", x => x.PhotoId);
//                    table.ForeignKey(
//                        name: "FK_PhotographFullImage_Photograph_PhotoId",
//                        column: x => x.PhotoId,
//                        principalTable: "Photograph",
//                        principalColumn: "PhotoId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_PhotographFullImage_PhotoId",
//                table: "PhotographFullImage",
//                column: "PhotoId",
//                unique: true);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "PhotographFullImage");

//            migrationBuilder.DropTable(
//                name: "Photograph");
//        }
//    }
//}
