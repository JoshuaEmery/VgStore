using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VgWebApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter a genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please select if this game has multiplayer")]
        public bool Multiplayer { get; set; }
        //I cannot remember whether we were going to assign games a rating
        //or if the rating would be calculated??
        //as it stands I did not include the Rating on the Product/Edit View
        //[Required(ErrorMessage = "Please enter a product name")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Please enter an ERSB rating")]
        public string ESRB { get; set; }


    }
}
