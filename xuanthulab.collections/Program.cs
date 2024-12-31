namespace xuanthulab.collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //PlayWithIList();
            PlayWithHashSet();

        }

        private static void PlayWithHashSet()
        {
            var hashSet = new HashSet<Product>
            {
                new Product { Id = 1, Name = "Cà phê", Price = 10000, Origin = "Việt Nam" },
                new Product { Id = 2, Name = "Trà", Price = 5000, Origin = "Việt Nam" },
                new Product { Id = 3, Name = "Cacao", Price = 20000, Origin = "Mỹ" },
                new Product { Id = 4, Name = "Sữa", Price = 15000, Origin = "Pháp" },
                new Product { Id = 5, Name = "Bánh", Price = 10000, Origin = "Việt Nam" }
            };
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (var product in hashSet)
            {
                Console.WriteLine(product);
            }
            // N format
            Console.WriteLine("Danh sách sản phẩm theo tên:");
            foreach (var product in hashSet)
            {
                Console.WriteLine(product.ToString("N"));
            }
        }

        private static void PlayWithIList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Cà phê", Price = 10000, Origin = "Việt Nam" },
                new Product { Id = 2, Name = "Trà", Price = 5000, Origin = "Việt Nam" },
                new Product { Id = 3, Name = "Cacao", Price = 20000, Origin = "Mỹ" },
                new Product { Id = 4, Name = "Sữa", Price = 15000, Origin = "Pháp" },
                new Product { Id = 5, Name = "Bánh", Price = 10000, Origin = "Việt Nam" }
            };
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            // N format
            Console.WriteLine("Danh sách sản phẩm theo tên:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString("N"));
            }

            // Sắp xếp theo giá
            products.Sort();
            Console.WriteLine("Danh sách sản phẩm theo giá:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }


    }
}
