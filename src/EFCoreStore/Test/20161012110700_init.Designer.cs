//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using EFCoreStore.Models;

//namespace EFCoreStore.Migrations
//{
//    [DbContext(typeof(EFCoreStoreContext))]
//    [Migration("20161012110700_init")]
//    partial class init
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "1.0.1")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("EFCoreStore.Models.Blog", b =>
//                {
//                    b.Property<int>("BlogId")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("Title")
//                        .IsRequired()
//                        .HasAnnotation("MaxLength", 256);

//                    b.Property<string>("Url")
//                        .IsRequired()
//                        .HasAnnotation("MaxLength", 1024);

//                    b.HasKey("BlogId");

//                    b.ToTable("Blog");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.BlogImage", b =>
//                {
//                    b.Property<int>("BlogImageId")
//                        .ValueGeneratedOnAdd();

//                    b.Property<int?>("BlogId");

//                    b.Property<string>("Caption")
//                        .HasAnnotation("MaxLength", 1024);

//                    b.Property<byte[]>("Image")
//                        .HasAnnotation("MaxLength", 2000);

//                    b.HasKey("BlogImageId");

//                    b.HasIndex("BlogId")
//                        .IsUnique();

//                    b.ToTable("BlogImage");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.Photograph", b =>
//                {
//                    b.Property<int>("PhotoId")
//                        .ValueGeneratedOnAdd();

//                    b.Property<byte[]>("ThumbnailBits");

//                    b.Property<string>("Title")
//                        .HasAnnotation("MaxLength", 1024);

//                    b.HasKey("PhotoId");

//                    b.ToTable("Photograph");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
//                {
//                    b.Property<int>("PhotoId");

//                    b.Property<byte[]>("HighResolutionBits")
//                        .HasAnnotation("MaxLength", 20000);

//                    b.HasKey("PhotoId");

//                    b.HasIndex("PhotoId")
//                        .IsUnique();

//                    b.ToTable("PhotographFullImage");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.Student", b =>
//                {
//                    b.Property<int>("StudentId")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnName("StudentId");

//                    b.Property<string>("Name")
//                        .IsRequired()
//                        .HasColumnName("Name")
//                        .HasAnnotation("MaxLength", 256);

//                    b.HasKey("StudentId");

//                    b.ToTable("Student");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.StudentImage", b =>
//                {
//                    b.Property<int?>("StudentId");

//                    b.Property<string>("Caption")
//                        .HasAnnotation("MaxLength", 1024);

//                    b.Property<byte[]>("Image")
//                        .HasAnnotation("MaxLength", 2000);

//                    b.HasKey("StudentId");

//                    b.HasIndex("StudentId")
//                        .IsUnique();

//                    b.ToTable("StudentImage");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.BlogImage", b =>
//                {
//                    b.HasOne("EFCoreStore.Models.Blog", "Blog")
//                        .WithOne("BlogImage")
//                        .HasForeignKey("EFCoreStore.Models.BlogImage", "BlogId");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
//                {
//                    b.HasOne("EFCoreStore.Models.Photograph", "Photograph")
//                        .WithOne("PhotographFullImage")
//                        .HasForeignKey("EFCoreStore.Models.PhotographFullImage", "PhotoId")
//                        .OnDelete(DeleteBehavior.Cascade);
//                });

//            modelBuilder.Entity("EFCoreStore.Models.StudentImage", b =>
//                {
//                    b.HasOne("EFCoreStore.Models.Student", "Student")
//                        .WithOne("StudentImage")
//                        .HasForeignKey("EFCoreStore.Models.StudentImage", "StudentId")
//                        .OnDelete(DeleteBehavior.Cascade);
//                });
//        }
//    }
//}
