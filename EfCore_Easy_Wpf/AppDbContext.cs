using Microsoft.EntityFrameworkCore;
using System;

namespace EfCore_Easy_Wpf.Model
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Product> Products { get; set; }
        //public DbSet<CustomerType> CustomerTypes { get; set; }
        //public DbSet<CustomerState> CustomerStates { get; set; }
        //public DbSet<PriceList> PriceLists { get; set; }
        //public DbSet<PriceListPosition> PriceListPositions { get; set; }
        //public DbSet<Currency> Currencies { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Hans Josef" },
                new Person { Id = 3, Name = "Shindy Shiny" }
                );

            // PRODUCT
            //modelBuilder.Entity<Product>().HasData(
            //    new Product { ProductID = 1, Title = "Pizza Hawaii", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 2, Title = "Burger", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 3, Title = "Pasta", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 4, Title = "Salad", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 5, Title = "Steak", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 6, Title = "Sushi", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 7, Title = "Ice Cream", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 8, Title = "Smoothie", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 9, Title = "Fries", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" },
            //    new Product { ProductID = 10, Title = "Nachos", IsActive = true, Created = DateTime.Now, Modified = DateTime.Now, CreatedBy = "dge" }
            //);

            // CUSTOMERTYPE
            //modelBuilder.Entity<CustomerType>().HasData(
            //    new CustomerType { CustomerTypeID = 1, Title = "Loyal", Notes = "Idky" },
            //    new CustomerType { CustomerTypeID = 2, Title = "New", Notes = "Just started" },
            //    new CustomerType { CustomerTypeID = 3, Title = "Regular", Notes = "Frequent buyer" },
            //    new CustomerType { CustomerTypeID = 4, Title = "VIP", Notes = "Exclusive perks" },
            //    new CustomerType { CustomerTypeID = 5, Title = "Inactive", Notes = "No longer active" },
            //    new CustomerType { CustomerTypeID = 6, Title = "Premium", Notes = "High-value customers" },
            //    new CustomerType { CustomerTypeID = 7, Title = "Premium", Notes = "High-value customers" },
            //    new CustomerType { CustomerTypeID = 8, Title = "Premium", Notes = "High-value customers" },
            //    new CustomerType { CustomerTypeID = 9, Title = "Premium", Notes = "High-value customers" },
            //    new CustomerType { CustomerTypeID = 9, Title = "Premium", Notes = "High-value customers" }
            //    );

            //// CUSTOMERSTATE
            //modelBuilder.Entity<CustomerState>().HasData(
            //    new CustomerState { CustomerStateID = 1, Title = "Active", Notes = "Active customer" },
            //    new CustomerState { CustomerStateID = 2, Title = "Inactive", Notes = "Inactive customer" },
            //    new CustomerState { CustomerStateID = 3, Title = "Pending", Notes = "Pending approval" },
            //    new CustomerState { CustomerStateID = 4, Title = "Blocked", Notes = "Blocked customer" },
            //    new CustomerState { CustomerStateID = 5, Title = "Suspended", Notes = "Suspended account" },
            //    new CustomerState { CustomerStateID = 6, Title = "Deleted", Notes = "Deleted customer" }
            //);

            //// PRICELIST
            //modelBuilder.Entity<PriceList>().HasData(
            //    new PriceList { PriceListID = 1, Title = "Standard", Description = "Standard price list" },
            //    new PriceList { PriceListID = 2, Title = "VIP", Description = "VIP price list" },
            //    new PriceList { PriceListID = 3, Title = "Special", Description = "Special price list" },
            //    new PriceList { PriceListID = 4, Title = "Promo", Description = "Promotional price list" },
            //    new PriceList { PriceListID = 5, Title = "Wholesale", Description = "Wholesale price list" }
            //);

            //// PRICELISTPOSITION
            //modelBuilder.Entity<PriceListPosition>().HasData(
            //    new PriceListPosition { PriceListPositionID = 1, PriceListID = 1, ProductID = 1, Price = 9.99 },
            //    new PriceListPosition { PriceListPositionID = 2, PriceListID = 1, ProductID = 2, Price = 5.99 },
            //    new PriceListPosition { PriceListPositionID = 3, PriceListID = 1, ProductID = 3, Price = 7.99 }
            //    // ... weitere Positionen ...
            //);

            //// CURRENCY
            //modelBuilder.Entity<Currency>().HasData(
            //    new Currency { CurrencyID = 1, Title = "USD", Symbol = "$" },
            //    new Currency { CurrencyID = 2, Title = "EUR", Symbol = "€" },
            //    new Currency { CurrencyID = 3, Title = "GBP", Symbol = "£" },
            //    new Currency { CurrencyID = 4, Title = "JPY", Symbol = "¥" }
            //);

            //// CUSTOMER
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", CustomerTypeID = 3, CustomerStateID = 1 },
            //    new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", CustomerTypeID = 2, CustomerStateID = 3 },
            //    new Customer { CustomerID = 3, FirstName = "Mike", LastName = "Johnson", CustomerTypeID = 1, CustomerStateID = 1 }
            //);


        }
    }
}