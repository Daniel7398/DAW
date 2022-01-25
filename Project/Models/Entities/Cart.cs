﻿using Project.Entities;
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

        public string UserId { get; set; }

        public  User User { get; set; }
        public  ICollection<Quantity> Quantities { get; set; }
    }
}
