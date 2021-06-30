using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Models
{
    public class AllianceMembers
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string Name { get; set; }
        public string AllianceTag { get; set; }
        public string Notes { get; set; }
    }
}