using DefinexService.DAL.Entity;
using DefinexService.DAL.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.DAL.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region DBSets
        public DbSet<BankList> BankLists { get; set; }
        public DbSet<BankGateway> BankGateway { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CreditCondition> CreditConditions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankList>()
                .HasData(
                new BankList { Id = 1, Name = "Is Bankasi", CreatedOn = DateTime.UtcNow },
                new BankList { Id = 2, Name = "Garanti", CreatedOn = DateTime.UtcNow },
                new BankList { Id = 3, Name = "Akbank", CreatedOn = DateTime.UtcNow }
                );

            modelBuilder.Entity<BankGateway>()
                .HasData(
                new BankGateway { Id = 1, ConfigurationId = 123, TerminalId = 123, ClientUsername = "test", ClientPassword = "test", CreatedOn = DateTime.UtcNow },
                new BankGateway { Id = 2, ConfigurationId = 123, TerminalId = 123, ClientUsername = "test", ClientPassword = "test", CreatedOn = DateTime.UtcNow },
                new BankGateway { Id = 3, ConfigurationId = 123, TerminalId = 123, ClientUsername = "test", ClientPassword = "test", CreatedOn = DateTime.UtcNow }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "ELEKTRONIK", CreatedOn = DateTime.UtcNow },
                new Category { Id = 2, Name = "OYUN", CreatedOn = DateTime.UtcNow },
                new Category { Id = 3, Name = "YAPI MALZEMESI", CreatedOn = DateTime.UtcNow }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "TEST1", Price = 5000, CategoryId = 1, CreatedOn = DateTime.UtcNow },
                new Product { Id = 2, Name = "TEST2", Price = 2000, CategoryId = 2, CreatedOn = DateTime.UtcNow },
                new Product { Id = 3, Name = "TEST3", Price = 7000, CategoryId = 3, CreatedOn = DateTime.UtcNow }
                );

            modelBuilder.Entity<CreditCondition>()
                .HasData(
                new CreditCondition { Id = 1, ConditionType = (ConditionType)1, BankType = (BankType)1, ConditionValue = "3500", BankGatewayId = 1 },
                new CreditCondition { Id = 2, ConditionType = (ConditionType)1, BankType = (BankType)2, ConditionValue = "3500", BankGatewayId = 2 },
                new CreditCondition { Id = 3, ConditionType = (ConditionType)1, BankType = (BankType)3, ConditionValue = "3500", BankGatewayId = 3 },
                new CreditCondition { Id = 4, ConditionType = (ConditionType)1, BankType = (BankType)1, ConditionValue = "3500", BankGatewayId = 1 },
                new CreditCondition { Id = 5, ConditionType = (ConditionType)1, BankType = (BankType)2, ConditionValue = "3500", BankGatewayId = 2 },
                new CreditCondition { Id = 6, ConditionType = (ConditionType)1, BankType = (BankType)3, ConditionValue = "3500", BankGatewayId = 3 }
                );
        }
    }
}
