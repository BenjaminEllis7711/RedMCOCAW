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
        public int AllianceId { get; set; }        
        public string AllianceTag { get; set; }
        public string Notes { get; set; }
        public List<RedMCOCAW.Data.Member> Members { get; set; }
    }
}
