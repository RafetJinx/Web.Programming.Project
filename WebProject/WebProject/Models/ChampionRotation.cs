using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class ChampionRotation
    {
        [Key]
        [Required]
        [ForeignKey("Champion")]
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
