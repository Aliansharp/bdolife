using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class MasteryAlchemy
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
        public decimal ImperialBonus { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal MaxProcChance { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal ChanceRegular { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal ChanceSpecial { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal ChanceRare { get; set; }
    }
}
