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
        
        public int MemberId { get; set; }
        
        public int ChampionId { get; set; }
        
        public Guid OwnerId { get; set; }
        public int? NodeAssignmentId { get; set; }
        public bool IsAssigned { get; set; }
    }
}
