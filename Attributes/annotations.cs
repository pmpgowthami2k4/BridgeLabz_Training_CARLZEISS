using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

//Required
//StringLength
//MaxLength
//MinLength
//Compare
//Range
//EmailAddress
//Phone
//RegularExpression
//DisplayName
//ReadOnly


class userRegistration
{

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters.")]
    public string username { get; set; }

    [Required(ErrorMessage ="Full name is mandatory")]
    [MaxLength(50)]
    public string fullName { get; set; }


    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string password { get; set; }

    [Compare("password",ErrorMessage = "Passwords do not match.")]
    public string confirmPassword { get; set; }

    [Range(16,60,ErrorMessage = "Age must be between 16 and 60.")]
    public int age { get; set; }


    [EmailAddress(ErrorMessage ="Invalid Email.")]
    public string email { get; set; }

    [Phone(ErrorMessage ="Invalid Phone Number")]
    public string phonenumber { get; set; }


    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Custom code must be alphanumeric.")]
    public string customcode { get; set; }

    [DisplayName("User ID")]
    [ReadOnly(true)]
    public int ID { get; set; }
}

class annotationsProgram
{
    static void Main()
    {
        userRegistration user = new userRegistration
        {
            username = "john_doe",
            fullName = "John Doe",
            password = "password123",
            confirmPassword = "password3",
            age = 25,
            email = "hello123",
            phonenumber = "1234567890",
            customcode = "abc",
        };


        var context = new ValidationContext(user);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(user, context, results, true);

        foreach (var validationResult in results)
        {

            if (!isValid)
            {
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("User is valid!");
            }
        }

    }
}