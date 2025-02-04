using System;
using System.ComponentModel.DataAnnotations;
namespace MVC1.Models
{
    //Model för personer
    public class Persons
    {
        public string? PerName { get; set; }

        public int Age { get; set; }
        public string? City { set; get; }

        [Required(ErrorMessage = "Du måste godkänna villkoren.")] //Meddelande vid fel
        [Range(typeof(bool), "true", "true", ErrorMessage = "Du måste godkänna villkoren.")] //Måste trycka i checkbox så att accept=ture
        public bool Accept { set; get; }

    }

}