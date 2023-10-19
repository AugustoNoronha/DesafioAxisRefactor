using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Models
{
    public class Cooperado
    {
        public int Id { get; set; }
        public int CooperativaId { get; set; }
        public Cooperativa Cooperativa { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContaCorrente { get; set; } = string.Empty;
        public ICollection<Favorito>? Favoritos { get; set; }

        public Cooperado(string name, string contaCorrente, int cooperativaId)
        {
            Name = name;
            ContaCorrente = contaCorrente;
            CooperativaId = cooperativaId;
        }
    }
}
