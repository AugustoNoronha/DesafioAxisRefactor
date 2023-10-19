using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Interfaces.Repositories
{
    public interface ICooperadoRepository
    {
        Task<List<Cooperado>> GetAllCooperados();
        Task CreateFavoritoCooperado(int idCooperado, CreateFavoritoDataTransfer favorito);
        Task<Cooperado> GetCooperadoById(int idCooperado);
    }
}
