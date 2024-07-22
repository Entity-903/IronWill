using System.IO;
using System.Numerics;
using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
    public class UserInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(5, int.MaxValue, ErrorMessage = "This is no place for children")]
        public int Age { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int? ZipCode { get; set; }

        public UserInput() { }

        public UserInput(string name, int age, string? street, string? city, string? state, int? zipCode)
        {
            Name = name;
            Age = age;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}


/*

    Name(cannot be blank or null)
    Age(cannot be less the 5)
    Address(Is jointly nullable; either all subfields or null or not)
        Street
        City
        State
        Zip Code

*/