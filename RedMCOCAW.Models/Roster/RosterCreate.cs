using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Roster
{
    public class RosterCreate
    {
        [Required]
        public int MemberId { get; set; }
        [Required]        
        public int ChampionId { get; set; }           
        
    }
}
