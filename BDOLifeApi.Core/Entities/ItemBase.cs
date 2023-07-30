using BDOLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public abstract class ItemBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string BDOReference { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Image { get; set; }
        public ItemTierEnum Tier { get; set; }
        public decimal Weight { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Effect { get; set; }
        public int? EffectDuration { get; set; }
        public int? Cooldown { get; set; }
        public bool Visible { get; set; }
        public virtual List<SellNPCItem> SellNPCs { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<ItemTranslate> Translates { get; set; }
        public string Discriminator { get; private set; }
    }
}
