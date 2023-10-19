using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Interfaces.Repositories;
using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Infrastructure.Repositories
{
    public class FavoritosRepository : IFavoritosRepository
    {
        private readonly DesafioAxisRefactorContext _context;

        public FavoritosRepository(DesafioAxisRefactorContext context)
        {
                _context = context;
        }
        public async Task<List<Favorito>> GetAllFavoritos()
        {
            return await _context.Favoritos.ToListAsync();
        }

        public async Task<List<Favorito>> GetAllFavoritosFromCooperado(int idCooperado)
        {
            return await _context.Favoritos.Where(e => e.CooperadoId == idCooperado).ToListAsync();
        }
        public Favorito GetFavoritoById(int idFavorito)
        {
            return _context.Favoritos.Where(e => e.Id == idFavorito).FirstOrDefault();
        }

        public async Task DeleteFavorito(int idFavorito)
        {
            await _context.Favoritos.Where(e => e.Id == idFavorito).ExecuteDeleteAsync();
            _context.SaveChanges();
        }

        public async Task UpdateFavorito(int idFavorito, UpdateFavoritoDataTransfer updateFavoritoDataTransfer)
        {
            await _context.Favoritos.Where(e => e.Id == idFavorito).
                .ExecuteUpdateAsync(
                    setter => setter.SetProperty(b => b.PixType, updateFavoritoDataTransfer.PixType)
                    .SetProperty(b => b.PixKey, updateFavoritoDataTransfer.PixKey)
                    );
            _context.SaveChanges();
        }
    }
}
