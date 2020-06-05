using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Boutique.Web.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]

        //public ICollection<Order> Orders { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}