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
//                name: "Blog",
//                columns: table => new
//                {
//                    BlogId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Title = table.Column<string>(maxLength: 256, nullable: false),
//                    Url = table.Column<string>(maxLength: 1024, nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Blog", x => x.BlogId);
//                });

//            migrationBuilder.CreateTable(
//                name: "Photograph",
//                columns: table => new
//                {
//                    PhotoId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    ThumbnailBits = table.Column<byte[]>(nullable: true),
//                    Title = table.Column<string>(maxLength: 1024, nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Photograph", x => x.PhotoId);
//                });

//            migrationBuilder.CreateTable(
//                name: "Student",
//                columns: table => new
//                {
//                    StudentId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Name = table.Column<string>(maxLength: 256, nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Student", x => x.StudentId);
//                });

//            migrationBuilder.CreateTable(
//                name: "BlogImage",
//                columns: table => new
//                {
//                    BlogImageId = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    BlogId = table.Column<int>(nullable: true),
//                    Caption = table.Column<string>(maxLength: 1024, nullable: true),
//                    Image = table.Column<byte[]>(maxLength: 2000, nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BlogImage", x => x.BlogImageId);
//                    table.ForeignKey(
//                        name: "FK_BlogImage_Blog_BlogId",
//                        column: x => x.BlogId,
//                        principalTable: "Blog",
//                        principalColumn: "BlogId",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "PhotographFullImage",
//                columns: table => new
//                {
//                    PhotoId = table.Column<int>(nullable: false),
//                    HighResolutionBits = table.Column<byte[]>(maxLength: 20000, nullable: true)
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

//            migrationBuilder.CreateTable(
//                name: "StudentImage",
//                columns: table => new
//                {
//                    StudentId = table.Column<int>(nullable: false),
//                    Caption = table.Column<string>(maxLength: 1024, nullable: true),
//                    Image = table.Column<byte[]>(maxLength: 2000, nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_StudentImage", x => x.StudentId);
//                    table.ForeignKey(
//                        name: "FK_StudentImage_Student_StudentId",
//                        column: x => x.StudentId,
//                        principalTable: "Student",
//                        principalColumn: "StudentId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_BlogImage_BlogId",
//                table: "BlogImage",
//                column: "BlogId",
//                unique: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_PhotographFullImage_PhotoId",
//                table: "PhotographFullImage",
//                column: "PhotoId",
//                unique: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_StudentImage_StudentId",
//                table: "StudentImage",
//                column: "StudentId",
//                unique: true);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "BlogImage");

//            migrationBuilder.DropTable(
//                name: "PhotographFullImage");

//            migrationBuilder.DropTable(
//                name: "StudentImage");

//            migrationBuilder.DropTable(
//                name: "Blog");

//            migrationBuilder.DropTable(
//                name: "Photograph");

//            migrationBuilder.DropTable(
//                name: "Student");
//        }
//    }
//}
