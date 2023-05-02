﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The Display order must be between 1 and 100")]
        public int Displayorder { get; set; }
        public DateTime Createddatetime { get; set; } = DateTime.Now;

    }
}
