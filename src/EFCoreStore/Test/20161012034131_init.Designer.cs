//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using EFCoreStore.Models;

//namespace EFCoreStore.Migrations
//{
//    [DbContext(typeof(EFCoreStoreContext))]
//    [Migration("20161012034131_init")]
//    partial class init
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "1.0.1")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("EFCoreStore.Models.Photograph", b =>
//                {
//                    b.Property<int>("PhotoId")
//                        .ValueGeneratedOnAdd();

//                    b.Property<byte[]>("ThumbnailBits");

//                    b.Property<string>("Title");

//                    b.HasKey("PhotoId");

//                    b.ToTable("Photograph");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
//                {
//                    b.Property<int>("PhotoId");

//                    b.Property<byte[]>("HighResolutionBits");

//                    b.HasKey("PhotoId");

//                    b.HasIndex("PhotoId")
//                        .IsUnique();

//                    b.ToTable("PhotographFullImage");
//                });

//            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
//                {
//                    b.HasOne("EFCoreStore.Models.Photograph", "Photograph")
//                        .WithOne("PhotographFullImage")
//                        .HasForeignKey("EFCoreStore.Models.PhotographFullImage", "PhotoId")
//                        .OnDelete(DeleteBehavior.Cascade);
//                });
//        }
//    }
//}
