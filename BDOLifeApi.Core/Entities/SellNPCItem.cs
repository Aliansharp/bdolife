using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class SellNPCItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid SellNPCId { get; set; }
        public virtual SellNPC SellNPC { get; set; }
        public Guid ItemId { get; set; }
        public virtual ItemBase Item { get; set; }
        public long Price { get; set; }
        public bool AmityRequired { get; set; }
    }
}
