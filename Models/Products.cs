using System;
using System.ComponentModel.DataAnnotations;

namespace market.Models{
    
   public class ProductsModel
    {
        [Key]
        public int ProductId { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }


        [Required]
        public bool OutOftuck { get; set; }


        [Required]
        public string ImageUrl { get; set; }


        [Required]
        public double Price { get; set; }

    }



}