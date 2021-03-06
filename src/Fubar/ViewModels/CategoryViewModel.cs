﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Fubar.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }
    }
}