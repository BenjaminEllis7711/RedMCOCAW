using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Data
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [ForeignKey(nameof(Alliance))]
        public int AllianceId { get; set; }
        public virtual Alliance Alliance { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
