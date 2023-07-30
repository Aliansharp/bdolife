using BDOLife.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class Recipe : ItemBase
    {
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public RecipeTypeEnum Type { get; set; }
        public ProcessingTypeEnum? SubType { get; set; }
        public SkillLevelEnum? SkillLevel { get; set; }
        public int EXP { get; set; }
        public int? QtdMaterial1 { get; set; }
        public int? QtdMaterial2 { get; set; }
        public int? QtdMaterial3 { get; set; }
        public int? QtdMaterial4 { get; set; }
        public int? QtdMaterial5 { get; set; }
        public Guid? Material1Id { get; set; }
        public Guid? Material2Id { get; set; }
        public Guid? Material3Id { get; set; }
        public Guid? Material4Id { get; set; }
        public Guid? Material5Id { get; set; }
        public virtual ItemBase Material1 { get; set; }
        public virtual ItemBase Material2 { get; set; }
        public virtual ItemBase Material3 { get; set; }
        public virtual ItemBase Material4 { get; set; }
        public virtual ItemBase Material5 { get; set; }
        public Guid? MaterialGroup1Id { get; set; }
        public virtual MaterialGroup MaterialGroup1 { get; set; }
        public Guid? MaterialGroup2Id { get; set; }
        public virtual MaterialGroup MaterialGroup2 { get; set; }
        public Guid? MaterialGroup3Id { get; set; }
        public virtual MaterialGroup MaterialGroup3 { get; set; }
        public Guid? MaterialGroup4Id { get; set; }
        public virtual MaterialGroup MaterialGroup4 { get; set; }
        public Guid? MaterialGroup5Id { get; set; }
        public virtual MaterialGroup MaterialGroup5 { get; set; }
        public Guid? Product1Id { get; set; }
        public Guid? Product2Id { get; set; }

        public decimal? QtdProduct1 { get; set; }
        public decimal? QtdProduct2 { get; set; }
        public virtual ItemBase Product1 { get; set; }
        public virtual ItemBase Product2 { get; set; }
    }
}
