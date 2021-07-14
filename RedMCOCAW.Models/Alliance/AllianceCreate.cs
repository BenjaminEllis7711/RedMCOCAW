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
        [Display(Name ="Alliance/BattleGroup Tag")]
        public string AllianceTag { get; set; }
        [MaxLength(500, ErrorMessage = "You don't need that long of a note.")]

        public string Notes { get; set; }
    }
}
