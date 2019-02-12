using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProektnaMVC.Models
{
    public class Tipster
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Country { get; set; }
        public virtual List<Pick> Picks { get; set; }
        public String Email { get; set; }

        public Tipster()
        {
            Picks = new List<Pick>();
        }
    }
}