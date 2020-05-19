using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Web.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Display(Name = "Dirección")]
        [MaxLength(400)]
        public string Address { get; set; }
        [Display(Name = "Teléfono")]
        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Correo")]
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
    }
}