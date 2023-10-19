using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Models
{
    public class Cooperativa
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Cooperado> Cooperados { get; set; }

        public Cooperativa(string description)
        {
            Description = description;
        }
    }
}
