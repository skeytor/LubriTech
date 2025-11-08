using LubriTech.Domain.Customers;
using LubriTech.Domain.Products;
using LubriTech.Domain.Purchasing;
using LubriTech.Domain.Sales;
using LubriTech.Domain.Suppliers;
using Microsoft.EntityFrameworkCore;

namespace LubriTech.Persistence.Abstractions;

public interface IAppDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Brand> Brands { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Supplier> Suppliers { get; }
    DbSet<Product> Products { get; }
    DbSet<Purchase> Purchases { get; }
    DbSet<PurchaseItem> PurchaseItems { get; }
    DbSet<SaleOrder> Sales { get; }
    DbSet<SaleItem> SalesItems { get; }
}
