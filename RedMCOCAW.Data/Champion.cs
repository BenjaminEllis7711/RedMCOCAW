using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Data
{
    public class Champion
    {
        [Key]
        public int ChampId { get; set; }    
        [Required]
        public string Name { get; set; }
    }
}