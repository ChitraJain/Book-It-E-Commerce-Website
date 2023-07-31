using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject_1.Models
{
   public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public string ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId ")]
        public Product Product { get; set; }
        [Range(1,1000,ErrorMessage="Please enter value between 1to100")]
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }

}
