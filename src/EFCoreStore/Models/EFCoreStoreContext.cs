using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

//http://www.cnblogs.com/Gyoung/archive/2013/01/25/2874589.html
//http://www.cnblogs.com/VolcanoCloud/p/4527549.html

namespace EFCoreStore.Models
{
    public class EFCoreStoreContext : DbContext
    {
        private string connectionString = "Data Source=S002;Initial Catalog=EFCoreTest; User ID=sa; Password=554321;Pooling=False";

        public EFCoreStoreContext()
        {

        }

        public EFCoreStoreContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            //Fluent API

            #region ComplexType 失败
            //modelBuilder.ComplexType<Address>();
            #endregion

            #region One-to-Zero-or-One

            #region 1 to 0..1
            //unique
            modelBuilder.Entity<Blog>()
                        .HasAlternateKey(b => b.Title);

            //not null
            modelBuilder.Entity<Blog>()
                        .Property(b => b.Url)
                        .IsRequired();

            //not mapped
            modelBuilder.Entity<Blog>()
                        .Ignore(b => b.LoadedFromDatabase);

            //各自有主键
            modelBuilder.Entity<Blog>()
                        .HasOne(p => p.BlogImage)
                        .WithOne(bi => bi.Blog)
                        .HasForeignKey<BlogImage>(b => b.BlogId);

            //modelBuilder.Entity<Student>()
            //            .HasOptional(s => s.Address) 
            //            .WithRequired(ad => ad.Student);
            #endregion

            #region 1 to 0..1 and  0..1 to 1
            //1 to 0..1
            modelBuilder.Entity<User>()
                        .HasOne(u => u.BillingAddress)
                        .WithOne();

            //0..1 to 1
            modelBuilder.Entity<Shipment>()
                        .HasOne(s => s.DeliveryAddress)
                        .WithOne()
                        .IsRequired();
            #endregion

            #region Shared Primary Key,1 to 1
            //共享主键
            // Configure PK 
            modelBuilder.Entity<DogAddress>()
                        .HasKey(da => da.DogId);

            // Configure Id as FK 
            modelBuilder.Entity<Dog>()
                        .HasOne(d => d.Address)
                        .WithOne()
                        .HasForeignKey<DogAddress>(da => da.DogId)
                        .IsRequired();

            //modelBuilder.Entity<Dog>()
            //            .HasOne(d => d.Address)
            //            .WithOne(a => a.Dog)
            //            .HasForeignKey<DogAddress>(da => da.DogtId)
            //            .IsRequired();

            //modelBuilder.Entity<Student>()
            //            .HasOptional(s => s.Address)
            //            .WithRequired(ad => ad.StudentId);
            #endregion

            #region Shared Primary Key,1 to 1
            //共享主键
            // Configure PhotoId as PK for PhotographFullImage
            modelBuilder.Entity<PhotographFullImage>()
                        .HasKey(pf => pf.PhotoId);

            // Configure PhotoId as FK for PhotographFullImage
            modelBuilder.Entity<Photograph>()
                        .HasOne(p => p.PhotographFullImage)
                        .WithOne()
                        .HasPrincipalKey<Photograph>(p => p.PhotoId)
                        .IsRequired();

            //modelBuilder.Entity<PhotographFullImage>()
            //            .HasOne(p => p.Photograph)
            //            .WithOne(pf => pf.PhotographFullImage)
            //            .HasPrincipalKey<Photograph>(p => p.PhotoId)
            //            .IsRequired();

            //modelBuilder.Entity<Student>()
            //            .HasRequired(s => s.Address)
            //            .WithRequiredPrincipal(ad => ad.Student);
            #endregion

            #endregion

            #region  One-or-Zero-to-Many
            #region 0..1 to *
            modelBuilder.Entity<Store>()
                        .HasAlternateKey(s => s.Name);

            modelBuilder.Entity<Store>()
                        .HasMany(s => s.Employees)
                        .WithOne(e => e.Store)
                        .HasForeignKey(s => s.EmployeeId);
            #endregion

            #region NoForeignKey,1 to 0..*
            //ComputedColumn
            modelBuilder.Entity<Staff>()
                        .Property(p => p.FullName)
                        .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

            //DefaultValueSql
            modelBuilder.Entity<Staff>()
                        .Property(p => p.HireDate)
                        .ForSqlServerHasDefaultValue("getdate()");

            modelBuilder.Entity<Staff>()
                        .HasOne(s => s.Department)
                        .WithMany(d => d.Staffs);

            //modelBuilder.Entity<Post>()
            //            .HasOne(p => p.Blog)
            //            .WithMany(b => b.Posts);
            #endregion

            #region OneNavigation,1 to 0..*
            modelBuilder.Entity<Order>()
                        .HasOne(o => o.BillingAddress)
                        .WithOne()
                        .HasForeignKey<Order>(o => o.BillingAddressId)
                        .IsRequired();

            modelBuilder.Entity<Order>()
                        .HasMany(o => o.OrderDetails)
                        .WithOne();
            #endregion
            #endregion

            #region Composite foreign key
            //modelBuilder.Entity<Car>()
            //    .HasKey(c => new { c.State, c.LicensePlate });

            //modelBuilder.Entity<RecordOfSale>()
            //    .HasOne(s => s.Car)
            //    .WithMany(c => c.SaleHistories)
            //    .HasForeignKey(s => new { s.CarState, s.CarLicensePlate });
            #endregion

            #region Principal Key
            //modelBuilder.Entity<SaleHistory>()
            //            .HasOne(s => s.Bus)
            //            .WithMany(b => b.SaleHistories)
            //            .HasForeignKey(s => new { s.LicensePlate })
            //            .HasPrincipalKey(b => new { b.LicensePlate });
            #endregion

            #region Many to many,* to *
            modelBuilder.Entity<EFCoreStore.Models.EventOrganizer>()
                        .HasKey(eo => new { eo.EventId, eo.OrganizerId });

            modelBuilder.Entity<EFCoreStore.Models.EventOrganizer>()
                        .HasOne(eo => eo.Event)
                        .WithMany(e => e.EventOrganizers)
                        .HasForeignKey(eo => eo.EventId);

            modelBuilder.Entity<EFCoreStore.Models.EventOrganizer>()
                        .HasOne(eo => eo.Organizer)
                        .WithMany(o =>o.EventOrganizers)
                        .HasForeignKey(eo => eo.OrganizerId);

            //modelBuilder.Entity<Student>()
            //            .HasMany<Course>(s => s.Courses)
            //            .WithMany(c => c.Students)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("StudentRefId");
            //                cs.MapRightKey("CourseRefId");
            //                cs.ToTable("StudentCourse");
            //            });
            #endregion

            #region Self Reference 
            #region One to many , 0..1 to *
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.SubCategories)
                        .WithOne(c => c.Parent)
                        .HasForeignKey(c=>c.ParentId);
            #endregion

            #region  Many to many ,* to *
            //modelBuilder.Entity<Product>()
            //      .HasMany(p => p.RelatedProducts)
            //      .WithOne(p => p.OtherRelatedProduct)
            //      .HasForeignKey(p => p.RelatedProductId)
            //      .HasPrincipalKey(p => p.ProductId);
            #endregion
            #endregion

            #region Many entities map a one table 失败
            //modelBuilder.Entity<Person>()
            //            .HasRequired(p => p.Photo)
            //            .WithRequiredPrincipal();

            //modelBuilder.Entity<PersonPhoto>()
            //            .HasKey(pp => pp.PersonId);

            //modelBuilder.Entity<Person>()
            //            .HasOne(p => p.Photo)
            //            .WithOne(pp => pp.Person)
            //            .HasPrincipalKey<PersonPhoto>(pp => pp.PersonId)
            //            .IsRequired();

            //modelBuilder.Entity<Person>().ToTable("People");
            //modelBuilder.Entity<PersonPhoto>().ToTable("People");
            #endregion

            #region One Entity Split Many Tables 失败
            //modelBuilder.Entity<Item>()
            //  .ToTable("Item")
            //  .Property(i => new { i.SKU, i.Description, i.Price });
            //modelBuilder.Entity<Item>()
            // .ToTable("ItemWebInfo").Property(i => new { i.SKU, i.ImageUrl });
            #endregion
        }

        #region ComplexType
        //public DbSet<EFCoreStore.Models.Dinner> Dinners { get; set; }
        #endregion

        #region One-to-Zero-or-One
        #region 1 to 0..1
        public DbSet<EFCoreStore.Models.Blog> Blogs { get; set; }

        public DbSet<EFCoreStore.Models.BlogImage> BlogImages { get; set; }
        #endregion

        #region 1 to 0..1 and  0..1 to 1
        public DbSet<EFCoreStore.Models.User> Users { get; set; }

        public DbSet<EFCoreStore.Models.Shipment> Shipments { get; set; }

        public DbSet<EFCoreStore.Models.Address> Addresses { get; set; }

        #endregion

        #region Shared Primary Key,1 to 0..1
        public DbSet<EFCoreStore.Models.Dog> Dogs { get; set; }

        public DbSet<EFCoreStore.Models.DogAddress> DogAddresses { get; set; }
        #endregion

        #region Shared Primary Key,1 to 0..1
        public DbSet<EFCoreStore.Models.Photograph> Photographs { get; set; }

        public DbSet<EFCoreStore.Models.PhotographFullImage> PhotographFullImages { get; set; }
        #endregion
        #endregion

        #region  One-or-Zero-to-Many
        #region 0..1 to *
        public DbSet<EFCoreStore.Models.Store> Stores { get; set; }

        public DbSet<EFCoreStore.Models.Employee> Employees { get; set; }
        #endregion

        #region NoForeignKey,1 to 0..*
        public DbSet<EFCoreStore.Models.Department> Departments { get; set; }

        public DbSet<EFCoreStore.Models.Staff> Staffs { get; set; }
        #endregion

        #region OneNavigation,1 to *
        public DbSet<EFCoreStore.Models.Order> Orders { get; set; }

        public DbSet<EFCoreStore.Models.OrderDetail> OrderDetails { get; set; }
        #endregion
        #endregion

        #region Composite foreign key
        //public DbSet<EFCoreStore.Models.Car> Cars { get; set; }

        //public DbSet<EFCoreStore.Models.RecordOfSale> RecordOfSales { get; set; }
        #endregion

        #region Principal Key
        //public DbSet<EFCoreStore.Models.Bus> Buses { get; set; }

        //public DbSet<EFCoreStore.Models.SaleHistory> SaleHistories { get; set; }
        #endregion

        #region Many to many,* to *
        public DbSet<EFCoreStore.Models.Event> Events { get; set; }

        public DbSet<EFCoreStore.Models.Organizer> Organizers { get; set; }

        public DbSet<EFCoreStore.Models.EventOrganizer> EventOrganizers { get; set; }
        #endregion

        #region Self Reference
        #region One to many , 0..1 to *
        public DbSet<EFCoreStore.Models.Category> Categories { get; set; }
        #endregion

        #region  Many to many ,* to *
        //public DbSet<EFCoreStore.Models.Product> Products { get; set; }
        #endregion
        #endregion

        #region Many entities map a one table
        //public DbSet<EFCoreStore.Models.Person> Persons { get; set; }

        //public DbSet<EFCoreStore.Models.Person> PersonPhotos { get; set; }
        #endregion

        #region One Entity Split Many Tables
        //public DbSet<EFCoreStore.Models.Item> Items { get; set; }
        #endregion
    }
}
