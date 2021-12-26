using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Champion
    {
        [Key]
        [Required]
        [StringLength(25)]
        public string Id { get; set; }

        [Required]
        public int Key { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Blurb { get; set; }
    }
}
