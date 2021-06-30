using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Roster
{
    public class RosterListItem
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int ChampionID { get; set; }
        public int? NodeId { get; set; }
        public bool IsAssigned { get; set; }
    }
}
