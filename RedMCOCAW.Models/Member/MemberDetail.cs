﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedMCOCAW.Models.Member
{
    public class MemberDetail
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int AllianceId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<string> ChampsOnRoster { get; set; } = new List<string>();
    }
}
