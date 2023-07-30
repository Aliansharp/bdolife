using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BDOLife.Core.Entities
{
    public class Server
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Language { get; set; }

        [JsonIgnore]
        [Column(TypeName = "varchar(250)")]
        public string MarketUrl { get; set; }

        [JsonIgnore]
        [Column(TypeName = "varchar(500)")]
        public string RequestVerificationToken { get; set; }
    }
}
