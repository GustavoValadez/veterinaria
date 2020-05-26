using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]

        //Los demas campos se encuentran al en IdentityModels



        public ApplicationUser ApplicationUser { get; set; }
    }
}