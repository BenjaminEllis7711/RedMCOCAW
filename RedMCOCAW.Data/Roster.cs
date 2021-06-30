using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Data
{
    public class Roster
    {       
        [Key, Column(Order = 0)]
        public int MemberId { get; set; }
        [Key, Column(Order = 1)]
        public int ChampionId { get; set; }
        [Key, Column(Order = 2)]
        public int NodeId { get; set; }
    }
}