using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Interfaces.Repositories
{
    public interface ICooperativaRepository
    {
        Task CreateCooperativa(CreateCooperativaDataTransfer cooperativa);
        Task CreateCooperadoByCooperativa(int idCooperativa, CreateCooperadoDataTransfer cooperado);
        Task<List<Cooperativa>> GetAllCoperativas();
        Cooperativa GetCoperativaById(int idCooperativa);
    }
}
