using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Data
{
    public class Alliance
    {
        [Key]
        public int AllianceId { get; set; }
        [Required]
        public string AllianceTag { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    }
}
