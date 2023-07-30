using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class MaterialGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string BDOReference { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public virtual List<ItemBase> Materials { get; set; }
        public virtual List<MaterialGroupTranslate> Translates { get; set; }
    }
}
