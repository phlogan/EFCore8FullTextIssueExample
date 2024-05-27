using Microsoft.EntityFrameworkCore;

namespace EFCore8FullTextIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FullTextExampleDataContext())
            {
                if (!db.Products.Any())
                {
                    Guid storeId = Guid.NewGuid();
                    Guid productId = Guid.NewGuid();
                    db.Products.Add(new Model.Product()
                    {
                        Name = "Product",
                        ProductId = productId,
                        TenantId = Cons.TENANT_ID
                    });
                    db.Stores.Add(new Model.Store()
                    {
                        StoreId = storeId,
                        TenantId = Cons.TENANT_ID
                    });
                    db.StoreProducts.Add(new Model.StoreProduct()
                    {
                        StoreProductId = Guid.NewGuid(),
                        ProductId = productId,
                        StoreId = storeId,
                        TenantId = Cons.TENANT_ID
                    });
                    db.SaveChanges();
                }
            }

            using (var db = new FullTextExampleDataContext())
            {
                var search = "duct";

                var example1 = db.Products.Where(e => EF.Functions.FreeText(e.Name, search));
                var example1QueryString = example1.ToQueryString();
                Console.WriteLine("Query Generated for Example 1:\r\n{0}\r\n\r\n", example1QueryString);
                var example1FirstOrDefault = example1.FirstOrDefault();

                var example2 = db.StoreProducts.Where(e => EF.Functions.FreeText(e.Product.Name, search));
                var example2QueryString = example2.ToQueryString();
                Console.WriteLine("Query Generated for Example 2:\r\n{0}\r\n\r\n", example2QueryString);
                var example2FirstOrDefault = example2.FirstOrDefault(); //Error

                ////With "Like", we have the same query structure, but it does not throws errors because it does not depend on indexed properties
                //var example3 = db.StoreProducts.Where(e => EF.Functions.Like(e.Product.Name, $"%{search}%"));
                //var example3QueryString = example3.ToQueryString();
                //Console.WriteLine("Query Generated for Example 3:\r\n{0}\r\n\r\n", example3QueryString);
                //var example3FirstOrDefault = example3.FirstOrDefault();
            }

            Console.ReadKey();
        }
    }
}