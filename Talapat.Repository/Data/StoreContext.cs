using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.Entities.Order_Aggregate;
using Talapat.Repository.Data.Configrations;

namespace Talapat.Repository.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.ApplyConfiguration(new ProductConfigrations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }


        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveyMethod> DeliveyMethods { get; set;}



    }
}
