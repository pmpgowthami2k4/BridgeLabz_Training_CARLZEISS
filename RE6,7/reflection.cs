using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static LibraryServiceImpl;

class ReflectionExample
{
    static void Main()
    {
        Book book = new Book(1, "AI Basics", "John Doe", "Science");

        Type type = typeof(Book);

        foreach (PropertyInfo prop in type.GetProperties())
        {
            //Check if BookCategoryAttribute is applied
            var attribute = prop.GetCustomAttribute<BookCategoryAttribute>();

            if (attribute != null)
            {
                Console.WriteLine($"Property '{prop.Name}' has BookCategoryAttribute");

                object value = prop.GetValue(book);

                ValidationContext context = new ValidationContext(book)
                {
                    MemberName = prop.Name
                };

                ValidationResult result = attribute.GetValidationResult(value, context);

                if (result == ValidationResult.Success)
                {
                    Console.WriteLine("Category is valid.");
                }
                else
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
        }
    }
}