using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Data
{
    public class NodeRoster
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Node))]
        public int NodeId { get; set; }
        public virtual Node Node { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Roster))]
        public int NodeAssignmentId { get; set; }
        public virtual Roster Roster { get; set; }
    }
}
