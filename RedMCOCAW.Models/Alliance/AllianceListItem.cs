using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedMCOCAW.Models.Alliance
{
    public class AllianceListItem
    {
        [Required]
        [Display(Name = "Alliance Id #")]

        public int AllianceId { get; set; }    
        [Display(Name ="Alliance/Battlegroup Tag")]

        public string AllianceTag { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Number of Members in Alliance")]
        public int MemberCount { get; set; }
    }
}
