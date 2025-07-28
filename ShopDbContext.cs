using project1.Models;
using System.Data.Entity;

namespace project1.Data
{
    // მონაცემთა ბაზის კონტექსტის კლასი, რომელიც წარმოადგენს მონაცემთა ბაზასთან კავშირს
    // და თითოეული ერთეულის/ცხრილის DbSet თვისებების გამოვლენა.
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("name=ShopDbContext")
        {
            // Lazy Loading-ის გამორთვა, რათა თავიდან ავიცილოთ დაკავშირებული ერთეულების ავტომატური ჩატვირთვა
            Configuration.LazyLoadingEnabled = false;

            // Disable database initialization (no automatic creation or migration)
            Database.SetInitializer<ShopDbContext>(null);
        }

        // მონაცემთა ბაზაში არსებული ყველა ცხრილისთვის DbSet თვისებების განსაზღვრა
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }
        public DbSet<CustomerRelationship> CustomerRelationships { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Entity-ების ურთიერთობებისა და შეზღუდვების კონფიგურაცია
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

 

            
            modelBuilder.Entity<CustomerRelationship>()
                .HasRequired(r => r.StartCustomer)
                .WithMany(c => c.StartedRelationships)
                .HasForeignKey(r => r.StartCustomerId)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<CustomerRelationship>()
                .HasRequired(r => r.EndCustomer)
                .WithMany(c => c.EndedRelationships)
                .HasForeignKey(r => r.EndCustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerRelationship>()
                .HasRequired(r => r.RelationshipType)
                .WithMany(rt => rt.CustomerRelationships)
                .HasForeignKey(r => r.RelationshipTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(s => s.CountryId)
                .HasColumnName("CountryId");

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(100);
        }
    }
}
 