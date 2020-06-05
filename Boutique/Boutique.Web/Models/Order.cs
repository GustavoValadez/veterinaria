using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Boutique.Web.Models
{
    public class Order
    {
        public int Id { get; set; }

        
        [Display(Name = "ID Artículo")]
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Total a pagar")]
        public decimal Total { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

    }
}