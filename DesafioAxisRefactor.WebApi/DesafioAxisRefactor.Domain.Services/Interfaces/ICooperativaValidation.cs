using DesafioAxisRefactor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Services.Interfaces
{
    public interface ICooperativaValidation
    {
        public bool RequestBodyValidation(Cooperativas cooperativa);
    }
}
