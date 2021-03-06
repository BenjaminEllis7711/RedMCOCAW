using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Roster
{
    public class RosterDetail
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int ChampionId { get; set; }
        public int? NodeAssignmentId { get; set; }
        public bool IsAssigned { get; set; }
        public string MemberName { get; set; }
        public string ChampName { get; set; }
    }
}
