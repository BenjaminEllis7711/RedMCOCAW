using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Node
{
    public class NodeCreate
    {
        [Required]
        public int NodeId { get; set; }
        
        public Guid OwnerId { get; set; }
        public string Details { get; set; }
    }
}
