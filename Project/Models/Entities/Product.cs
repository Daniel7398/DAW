using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(60, ErrorMessage = "Numele nu poate contine mai mult de 60 caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        [DataType(DataType.MultilineText)]
        public string Descriere { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pretul nu poate fi negativ")]
        public float Pret { get; set; }

        [Required(ErrorMessage = "Poza e obligatorie")]
        public string Poza { get; set; }

        [Required(ErrorMessage = "Categoria este obligatorie")]
        public int CategoryId { get; set; }

        public float Rating { get; set; }

        public bool Cerere { get; set; }

        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Categ { get; set; }

        public User User { get; set; }
        public  Category Category { get; set; }
        public  ICollection<Review> Reviews { get; set; }

        public  ICollection<Quantity> Quantities { get; set; }
    }
}
