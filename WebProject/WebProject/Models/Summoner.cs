using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Summoner
    {
        [Key]
        [StringLength(150)]
        [Required]
        [Display(Name = "Summoner Id")]
        public string Id { get; set; }

        [StringLength(150)]
        [Required]
        public string AccountId { get; set; }

        [StringLength(250)]
        [Required]
        public string PuuId { get; set; }

        [StringLength(25)]
        [Required]
        [Display(Name = "Summoner Name")]
        public string Name { get; set; }

        [Required]
        public int ProfileIconId { get; set; }

        [Required]
        public DateTime RevisionDate { get; set; }

        [Required]
        public int SummonerLevel { get; set; }
    }
}
