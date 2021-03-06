﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Amenity Name")]
        public string Name { get; set; }


        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
