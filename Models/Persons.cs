using System;
using System.ComponentModel.DataAnnotations;
namespace MVC1.Models
{
    //Klass för personer
    public class Persons
    {
        public string? PerName { get; set; }

        public int Age { get; set; }
        public string? City { set; get; }

        [Required(ErrorMessage = "Du måste godkänna villkoren.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Du måste godkänna villkoren.")]
        public bool Accept { set; get; }

    }

}