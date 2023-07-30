using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class MasteryCooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Mastery { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal RegularProc { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal RareProc { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal CraftForDurability { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal ImperialBonus { get; set; }

        [Column(TypeName = "decimal(5, 4)")]
        public decimal RegularMaxProcChance { get; set; }

        [Column(TypeName = "decimal(5, 4)")]
        public decimal RareMaxProcChance { get; set; }

    }
}
