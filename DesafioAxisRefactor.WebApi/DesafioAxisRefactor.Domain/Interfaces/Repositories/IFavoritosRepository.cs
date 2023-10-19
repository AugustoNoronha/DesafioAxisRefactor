using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Interfaces.Repositories
{
    public interface IFavoritosRepository
    {
        Task<List<Favorito>> GetAllFavoritos();
        Task<List<Favorito>> GetAllFavoritosFromCooperado(int idCooperado);
        Favorito GetFavoritoById(int idFavorito);
        Task DeleteFavorito(int idFavorito);
        Task UpdateFavorito(int idFavorito, UpdateFavoritoDataTransfer updateFavoritoDataTransfer);

    }
}
