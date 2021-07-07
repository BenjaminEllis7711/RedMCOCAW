using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.NodeRoster
{
    public class NodeRosterModel
    {
        [Required]
        public int NodeId { get; set; }
        [Required]
        public int NodeAssignmentId { get; set; }
    }
}
