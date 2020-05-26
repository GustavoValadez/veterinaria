using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Veterinary
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(150)]
        public string Description { get; set; }

        //Los demas campos se encuentran al en IdentityModels


        //Porque existe una relacion de 1 a * se recomienda poner un ICollection
        public ICollection<Consult> Consults { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}