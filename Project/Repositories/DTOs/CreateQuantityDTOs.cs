using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class CreateQuantityDTOs
    {
        public int QuantityId { get; set; }
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Cantitate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
