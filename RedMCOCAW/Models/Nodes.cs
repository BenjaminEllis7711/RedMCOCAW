﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Models
{
    public class Nodes
    {
        [Key]
        public int NodeId { get; set; }
        public string Details { get; set; }
        public int RosterId { get; set; }
    }
}