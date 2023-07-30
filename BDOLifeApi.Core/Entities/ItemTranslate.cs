using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class ItemTranslate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //public Guid ServerId { get; set; }
        //public virtual Server Server { get; set; }
        public Guid ItemId { get; set; }
        public virtual ItemBase Item { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string NameTranslated { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Lang { get; set; }
    }
}
