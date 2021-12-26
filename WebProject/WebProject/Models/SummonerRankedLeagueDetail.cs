using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class SummonerRankedLeagueDetail
    {
        [Key]
        [Required]
        [StringLength(150)]
        public string LeagueId { get; set; }

        [Required]
        [StringLength(50)]
        public string QueueType { get; set; }

        [Required]
        [StringLength(25)]
        public string Tier { get; set; }

        [Required]
        public int Rank { get; set; }

        [Required]
        [ForeignKey("Summoner")]
        public string SummonerId { get; set; }
        public virtual Summoner Summoner { get; set; }

        [Required]
        public int LeaguePoint { get; set; }

        [Required]
        public int Win { get; set; }

        [Required]
        public int Losses { get; set; }

        [Required]
        public bool Veteran { get; set; }

        [Required]
        public bool Inactive { get; set; }

        [Required]
        public bool FreshBlood { get; set; }

        [Required]
        public bool HotStreak { get; set; }
    }
}
