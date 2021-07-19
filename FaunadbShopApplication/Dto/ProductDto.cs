using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Dto
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}
