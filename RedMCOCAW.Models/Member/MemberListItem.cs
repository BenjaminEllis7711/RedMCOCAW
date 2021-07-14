using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Member
{
    public class MemberListItem
    {
        [Required]
        [Display(Name = "Member Id #")]
        public int MemberId { get; set; }
        [Required]
        [Display(Name = "Alliance Id #")]
        public int AllianceId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Alliance/Battlegroup Tag")]        
        public string AllianceTag { get; set; }

    }
}
