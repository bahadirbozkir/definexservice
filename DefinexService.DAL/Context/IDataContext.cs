using DefinexService.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.DAL.Context
{
    public interface IDataContext
    {
        DbSet<BankList> BankLists { get; set; }
        DbSet<BankGateway> BankGateway { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItems> BasketItems { get; set; }
        DbSet<Category> Categories{ get; set; }
        DbSet<Product> Products { get; set; }       
        DbSet<CreditCondition> CreditConditions { get; set; }       

    }
}
