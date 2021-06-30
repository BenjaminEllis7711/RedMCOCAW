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
        public int MemberId { get; set; }        
        public int AllianceName { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public ICollection<RedMCOCAW.Data.Roster> Roster { get; set; }
    }
}
