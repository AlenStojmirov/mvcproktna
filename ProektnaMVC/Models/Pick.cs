    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProektnaMVC.Models
{
    public class Pick
    {

        public int Id { get; set; }
        [Display(Name ="Tipster")]    
        public int TipsterId { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Sport")]
        public string Sport { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Game")]
        public string Game { get; set; }

        [Required]
        [Display(Name = "Pick")]
        public string Picks { get; set; }

        [Required]
        [Display(Name = "ODDS")]
        public float Odds { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Stake")]
        public int Stake { get; set; }

        [Required]
        [Display(Name = "Bookmaker")]
        public string Bookmaker { get; set; }

        [Required]
        [Display(Name = "Result")]
        public string Result { get; set; }
        
        public Tipster Tipster { get; set; }

        public Pick() { }

        public Pick(DateTime data, string sport, string coutnry, string game, string pick, float odds, int stake, string bookmaker,string result)
        {
            Data = data;
            Sport = sport;
            Country = coutnry;
            Game = game;
            Picks = pick;
            Odds = odds;
            Stake = stake;
            Bookmaker = bookmaker;
            Result = result;
        }

    }
}