using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Models
{
    public class Favorito
    {
        public long Id { get; set; }
        public int CooperadoId { get; set; }
        public string Name { get; set; } = string.Empty;
        public PixType PixType { get; set; }
        public string PixKey { get; set; } = string.Empty;
        public Cooperado Cooperado { get; set; }


        public Favorito(string name, PixType pixType, string pixKey, int cooperadoId)
        {
            Name = name;
            PixType = pixType;
            PixKey = pixKey;
            CooperadoId = cooperadoId;
        }
    }

    public enum PixType
    {
        CPF = 0,
        CNPJ = 1,
        EMAIL = 2,
        TELEFONE = 3,
        ALEATORIA = 4
    }
}