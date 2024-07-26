using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.Entities.Order_Aggregate;

namespace Talapat.Repository.Data
{
    public static class StoreContextSeed
    {

        // Seeding
        public static async Task SeedAsync( StoreContext dbcontext)
        {
            // Serialize:json to String
            //seeding brands
            if (!dbcontext.productBrands.Any()) // if the table is empty do ....
            {
                var BrandsData = File.ReadAllText("../Talapat.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (brands?.Count > 0)
                {
                    foreach (var Brand in brands)
                    {
                        await dbcontext.Set<ProductBrand>().AddAsync(Brand); // added localy
                    }
                    await dbcontext.SaveChangesAsync();

                }
            }
            // seedind types
         if (!dbcontext.productTypes.Any())
            {
                var TypesData = File.ReadAllText("../Talapat.Repository/Data/DataSeed/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                if (types?.Count > 0)
                {
                    foreach (var type in types)
                    {
                        await dbcontext.Set<ProductType>().AddAsync(type);
                    }
                    await dbcontext.SaveChangesAsync();

                }
            }
            //seeding product
            if (!dbcontext.products.Any())
            {

                var ProductData = File.ReadAllText("../Talapat.Repository/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                if (Products?.Count > 0)
                {
                    foreach (var Product in Products)
                    {
                        await dbcontext.Set<Product>().AddAsync(Product);
                    }
                    await dbcontext.SaveChangesAsync();

                }
            }


            if (!dbcontext.DeliveyMethods.Any())
            {

                var DeliveyMethodsData = File.ReadAllText("../Talapat.Repository/Data/DataSeed/delivery.json");
                var DeliveyMethods = JsonSerializer.Deserialize<List<DeliveyMethod>>(DeliveyMethodsData);
                if (DeliveyMethods?.Count > 0)
                {
                    foreach (var DeliveyMethod in DeliveyMethods)
                    {
                        await dbcontext.Set<DeliveyMethod>().AddAsync(DeliveyMethod);
                    }
                    await dbcontext.SaveChangesAsync();

                }
            }





        }


    }
}
