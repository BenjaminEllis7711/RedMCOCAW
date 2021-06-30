using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RedMCOCAW.Data
{
    public class Roster
    {       
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Champion))]
        public int ChampionId { get; set; }
        public virtual Champion Champion { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey(nameof(Node))]
        public int? NodeId { get; set; }
        public virtual Node Node { get; set; }

        public bool IsAssigned
        {
            get
            {
                if (Node == null) return false;
                else return true;
            }
        }
    }
}