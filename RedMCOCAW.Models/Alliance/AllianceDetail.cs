using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Alliance
{
    public class AllianceDetail
    {
        public int AllianceId { get; set; }        
        public Guid OwnerId { get; set; }        
        public string AllianceTag { get; set; }
        public string Notes { get; set; }

    }
}
