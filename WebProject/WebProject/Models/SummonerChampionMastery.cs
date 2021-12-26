using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebProject.Models
{
    public class SummonerChampionMastery
    {
        [Key]
        [StringLength(25)]
        [ForeignKey("Champion")]
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }

        [Required]
        public int ChampionLevel { get; set; }

        [Required]
        public int ChampionPoint { get; set; }

        [Required]
        public DateTime LastPlayTime { get; set; }

        [Required]
        public bool ChestGranted { get; set; }

        [Required]
        public int TokensEarned { get; set; }

        [Required]
        [ForeignKey("Summoner")]
        public string SummonerId { get; set; }
        public virtual Summoner Summoner { get; set; }
    }
}
