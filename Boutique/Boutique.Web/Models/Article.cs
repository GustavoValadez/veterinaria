using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boutique.Web.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Artículo")]
        [MaxLength(50)]
        public string ArticleName { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Color")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Tamaño")]
        [MaxLength(50)]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Imagen")]
        public string ImgUrl { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}