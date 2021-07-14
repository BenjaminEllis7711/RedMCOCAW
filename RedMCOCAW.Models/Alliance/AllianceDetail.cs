using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Alliance
{
    public class AllianceDetail
    {
        [Required]
        [Display(Name ="Alliance Id #")]
        public int AllianceId { get; set; }
        [Display(Name = "Alliance/BattleGroup Tag")]       
        public string AllianceTag { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Alliance Members")]
        public List<string> MembersOnTeam { get; set; }

    }
}
