﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yd.Models
{
    public class Picture
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public String Path { get; set; }
    }
}
