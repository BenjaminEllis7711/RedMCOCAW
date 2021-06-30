using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Data
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        public string Details { get; set; }        
    }
}