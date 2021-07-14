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
        [Display(Name="Member Id #")]
        public int MemberId { get; set; }
        [Required]
        [Display(Name = "Champion Id #")]
        public int ChampionId { get; set; }
        [Display(Name = "Node Assignment")]
        public int? NodeAssignmentId { get; set; }
        [Display(Name = "Is Assigned to Node")]
        public bool IsAssigned { get; set; }
        [Display(Name = "Member's Name")]
        public string MemberName { get; set; }
        [Display(Name = "Champion's Name")]
        public string ChampionName { get; set; }
        [Display(Name = "Node Description")]
        public string NodeDescription { get; set; }
    }
}
