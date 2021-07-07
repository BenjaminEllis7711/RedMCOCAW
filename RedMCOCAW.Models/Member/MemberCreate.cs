using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Member
{
    public class MemberCreate
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public int AllianceId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
