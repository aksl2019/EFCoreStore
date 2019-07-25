using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreStore.Models;

namespace EFCoreStore.Migrations
{
    [DbContext(typeof(EFCoreStoreContext))]
    partial class EFCoreStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreStore.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Contry")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EFCoreStore.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("BlogId");

                    b.HasAlternateKey("Title");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("EFCoreStore.Models.BlogImage", b =>
                {
                    b.Property<int>("BlogImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlogId");

                    b.Property<string>("Caption")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<byte[]>("Image")
                        .HasAnnotation("MaxLength", 2000);

                    b.HasKey("BlogImageId");

                    b.HasIndex("BlogId")
                        .IsUnique();

                    b.ToTable("BlogImage");
                });

            modelBuilder.Entity("EFCoreStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<int?>("ParentId")
                        .HasColumnName("ParentId");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnName("Path")
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EFCoreStore.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepartmentId");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EFCoreStore.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DogId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("DogId");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("EFCoreStore.Models.DogAddress", b =>
                {
                    b.Property<int>("DogtId")
                        .HasColumnName("DogtId");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnName("Address1")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<string>("Address2")
                        .HasColumnName("Address2")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Contry")
                        .IsRequired()
                        .HasColumnName("Contry")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<string>("PostCode")
                        .HasColumnName("PostCode")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("State")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("DogtId");

                    b.HasIndex("DogtId")
                        .IsUnique();

                    b.ToTable("DogAddress");
                });

            modelBuilder.Entity("EFCoreStore.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int?>("StoreId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EFCoreStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderId");

                    b.Property<int>("BillingAddressId")
                        .HasColumnName("BillingAddressId");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnName("CustomerName")
                        .HasAnnotation("MaxLength", 160);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("OrderDate");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasAnnotation("MaxLength", 24);

                    b.HasKey("OrderId");

                    b.HasIndex("BillingAddressId")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EFCoreStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderDetailId");

                    b.Property<int?>("OrderId");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("EFCoreStore.Models.Photograph", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ThumbnailBits")
                        .HasAnnotation("MaxLength", 10000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("PhotoId");

                    b.ToTable("Photograph");
                });

            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
                {
                    b.Property<int>("PhotoId");

                    b.Property<byte[]>("HighResolutionBits")
                        .HasAnnotation("MaxLength", 20000);

                    b.HasKey("PhotoId");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("PhotographFullImage");
                });

            modelBuilder.Entity("EFCoreStore.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DeliveryAddressId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("ShipmentId");

                    b.HasIndex("DeliveryAddressId")
                        .IsUnique();

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("EFCoreStore.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

                    b.Property<string>("HireDate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:DefaultValue", "getdate()");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("StaffId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("EFCoreStore.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("StoreId");

                    b.HasAlternateKey("Name");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("EFCoreStore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillingAddressId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.HasKey("UserId");

                    b.HasIndex("BillingAddressId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("EFCoreStore.Models.BlogImage", b =>
                {
                    b.HasOne("EFCoreStore.Models.Blog", "Blog")
                        .WithOne("BlogImage")
                        .HasForeignKey("EFCoreStore.Models.BlogImage", "BlogId");
                });

            modelBuilder.Entity("EFCoreStore.Models.Category", b =>
                {
                    b.HasOne("EFCoreStore.Models.Category", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("EFCoreStore.Models.DogAddress", b =>
                {
                    b.HasOne("EFCoreStore.Models.Dog")
                        .WithOne("Address")
                        .HasForeignKey("EFCoreStore.Models.DogAddress", "DogtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreStore.Models.Employee", b =>
                {
                    b.HasOne("EFCoreStore.Models.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreStore.Models.Order", b =>
                {
                    b.HasOne("EFCoreStore.Models.Address", "BillingAddress")
                        .WithOne()
                        .HasForeignKey("EFCoreStore.Models.Order", "BillingAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreStore.Models.OrderDetail", b =>
                {
                    b.HasOne("EFCoreStore.Models.Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("EFCoreStore.Models.PhotographFullImage", b =>
                {
                    b.HasOne("EFCoreStore.Models.Photograph")
                        .WithOne("PhotographFullImage")
                        .HasForeignKey("EFCoreStore.Models.PhotographFullImage", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreStore.Models.Shipment", b =>
                {
                    b.HasOne("EFCoreStore.Models.Address", "DeliveryAddress")
                        .WithOne()
                        .HasForeignKey("EFCoreStore.Models.Shipment", "DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreStore.Models.Staff", b =>
                {
                    b.HasOne("EFCoreStore.Models.Department", "Department")
                        .WithMany("Staffs")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("EFCoreStore.Models.User", b =>
                {
                    b.HasOne("EFCoreStore.Models.Address", "BillingAddress")
                        .WithOne()
                        .HasForeignKey("EFCoreStore.Models.User", "BillingAddressId");
                });
        }
    }
}
