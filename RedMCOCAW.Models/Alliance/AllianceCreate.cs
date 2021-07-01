using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Alliance
{
    public class AllianceCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Tag must be atleast 2 characters long")]
        [MaxLength(6, ErrorMessage = "Tag must be six characters or less")]
        public string AllianceTag { get; set; }
        
        public string Notes { get; set; }
    }
}
