﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [MaxLength(50)]
        public string PetType { get; set; }

        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Color")]
        [MaxLength(50)]
        public string Color { get; set; }

        [Display(Name = "Raza")]
        [MaxLength(50)]
        public string Race { get; set; }

        [Required]
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }
   
        [Required]
        [Display(Name = "Altura")]
        public decimal Height { get; set; }

        [Display(Name = "Imagen")]
        public string ImgUrl { get; set; }

        [Display(Name = "Dueño")]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]

        public Owner Owner { get; set; }

        //Porque existe una relacion de 1 a * se recomienda poner un ICollection
        public ICollection<Pet> Pets { get; set; }
    }
}