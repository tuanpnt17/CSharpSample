using System.ComponentModel.DataAnnotations;

namespace xuanthulab.attribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TestProduct();
            TestStudent();
        }

        private static void TestStudent()
        {
            var student = new Student()
            {
                Name = "John",
                Email = "join@gmail.com",
                Password = "123456",
                ConfirmPassword = "123456",
                BirthDate = new DateTime(2020, 1, 1),
            };
            var context = new ValidationContext(student);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(student, context, results, true);
            if (isValid)
            {
                Console.WriteLine("Student is valid");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ErrorMessage);
                }
            }
        }

        private static void TestProduct()
        {
            var product = new Product() { Name = "Laptop", Price = 1000 };
            //product.PrintProduct();

            // Read attribute of class
            GetClassAttribute(product);

            Console.WriteLine("--------------------------------");
            // Read attribute of properties
            GetPropertyAttribute(product);

            Console.WriteLine("--------------------------------");
            //Read attribute of methods
            GetMethodAttribute(product);
        }

        private static void GetMethodAttribute(Product product)
        {
            var methods = product.GetType().GetMethods();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is DescAttribute descAttribute)
                    {
                        Console.WriteLine(
                            $"{method.Name, 10} has attribute: {descAttribute.Description}"
                        );
                    }
                }
            }
        }

        private static void GetPropertyAttribute(Product product)
        {
            var properties = product.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is DescAttribute descAttribute)
                    {
                        Console.WriteLine(
                            $"{property.Name, 10} has attribute: {descAttribute.Description}"
                        );
                    }
                }
            }
        }

        private static void GetClassAttribute(Product product)
        {
            var customAttributes = product.GetType().GetCustomAttributes(false);
            foreach (var attribute in customAttributes)
            {
                if (attribute is DescAttribute descAttribute)
                {
                    Console.WriteLine(
                        $"{product.GetType().Name, 10} has attribute: {descAttribute.Description}"
                    );
                }
            }
        }
    }
}
