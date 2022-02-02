using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int categoryId { get; set; }
        [Required]
        public string category { get; set; }
    }
}
