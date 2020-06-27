using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial007.API.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public string ContentName { get; set; }

        [Required]
        public string Content { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
