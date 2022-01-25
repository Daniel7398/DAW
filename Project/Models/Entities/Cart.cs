using Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Entities
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }

        public int UserForeignKey { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Quantity> Quantities { get; set; }
    }
}
