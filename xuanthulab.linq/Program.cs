namespace xuanthulab.linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var brands = new List<Brand>
            {
                new Brand { Id = 1, Name = "Apple" },
                new Brand { Id = 2, Name = "Samsung" },
                new Brand { Id = 3, Name = "Xiaomi" },
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "IPhone 15",
                    BrandId = 1,
                    Price = 5000,
                    Colors = ["Blue", "Red"],
                },
                new Product
                {
                    Id = 2,
                    Name = "Galaxy S23",
                    BrandId = 2,
                    Price = 4500,
                    Colors = ["Black", "White"],
                },
                new Product
                {
                    Id = 3,
                    Name = "Mi 13",
                    BrandId = 3,
                    Price = 4000,
                    Colors = ["Green", "Yellow"],
                },
                new Product
                {
                    Id = 4,
                    Name = "IPhone 14",
                    BrandId = 1,
                    Price = 4000,
                    Colors = ["Blue", "Red"],
                },
                new Product
                {
                    Id = 5,
                    Name = "Galaxy S22",
                    BrandId = 2,
                    Price = 3500,
                    Colors = ["Black", "White"],
                },
                new Product
                {
                    Id = 6,
                    Name = "Mi 12",
                    BrandId = 3,
                    Price = 3000,
                    Colors = ["Green", "Yellow"],
                },
                new Product
                {
                    Id = 7,
                    Name = "IPhone 13",
                    BrandId = 1,
                    Price = 3000,
                    Colors = ["Blue", "Red"],
                },
                new Product
                {
                    Id = 8,
                    Name = "Galaxy S21",
                    BrandId = 2,
                    Price = 2500,
                    Colors = ["Black", "White"],
                },
            };

            PrintList<Product>(GetProductsWithPriceLessThan4000(products));
            Console.WriteLine("-------------------------------------------------");
            PrintList<double>(GetProductPricesWithColorBlueAndProductPriceLessThan5000(products));
            Console.WriteLine("-------------------------------------------------");
            PrintList<Product>(
                GetProductsWithBrandNameOrderByPriceAscending(products, brands, "Apple")
            );
            Console.WriteLine("-------------------------------------------------");
            var result = products
                .Where(product => product.Price >= 5500)
                .GroupBy(product => product.Price)
                .OrderByDescending(gr => gr.Key);

            var conn = products
                .GroupBy(product => product.Price)
                .Select(gr => new { gr, count = gr.Count() })
                .Select(@t => new { Price = @t.gr.Key, Count = @t.count });
            PrintList(conn);

            var joined = products
                .Join(
                    brands,
                    product => product.BrandId,
                    brand => brand.Id,
                    (product, brand) => new { product, brand }
                )
                .Where(@t => @t.brand.Name == "Apple")
                .OrderBy(@t => @t.product.Price)
                .Select(@t => @t.product);
            PrintList(joined);

            var leftJoined = brands
                .GroupJoin(
                    products,
                    brand => brand.Id,
                    product => product.BrandId,
                    (brand, productToReturn) => new { brand, products = productToReturn }
                )
                .SelectMany(
                    @t => @t.products.DefaultIfEmpty(),
                    (@t, product) => new { @t, product }
                )
                .Where(@t => @t.product != null)
                .Select(@t => @t.product);
        }

        private static IEnumerable<Product> GetProductsWithBrandNameOrderByPriceAscending(
            List<Product> products,
            List<Brand> brands,
            string apple
        )
        {
            return products
                .Where(product =>
                    brands.Any(brand => brand.Name == apple && brand.Id == product.BrandId)
                )
                .OrderBy(product => product.Price);
        }

        private static IEnumerable<double> GetProductPricesWithColorBlueAndProductPriceLessThan5000(
            List<Product> products
        )
        {
            return products
                .Where(product => product.Colors.Contains("Blue") && product.Price < 5000)
                .Select(product => product.Price);
        }

        private static IEnumerable<Product> GetProductsWithPriceLessThan4000(List<Product> products)
        {
            return products.Where(product => product.Price < 4000);
        }

        private static void PrintList<T>(IEnumerable<T> listItems)
        {
            foreach (var item in listItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
