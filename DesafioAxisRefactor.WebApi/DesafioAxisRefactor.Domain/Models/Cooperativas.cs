using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Models
{
    [Table("cooperativas")]
    public class Cooperativas
    {
        public long Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;
    }
}
