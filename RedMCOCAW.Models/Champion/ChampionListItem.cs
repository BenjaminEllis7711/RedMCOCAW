using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Champion
{
    public class ChampionListItem
    {
        [Required]
        public int ChampId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
