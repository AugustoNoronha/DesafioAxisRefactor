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
    public class CooperadoRepository : ICooperadoRepository
    {
        private readonly DesafioAxisRefactorContext _context;
        public CooperadoRepository(DesafioAxisRefactorContext context)
        {
            _context = context;       
        }

        public async Task CreateFavoritoCooperado(int idCooperado, CreateFavoritoDataTransfer favorito)
        {
            Favorito addFavorito = new Favorito(favorito.Name, favorito.PixType, favorito.PixKey, idCooperado);

            await _context.Favoritos.AddAsync(addFavorito);
            _context.SaveChanges();
        }

        public async Task<List<Cooperado>> GetAllCooperados()
        {
           return await _context.Cooperados.ToListAsync();
        }

        public async Task<Cooperado> GetCooperadoById(int idCooperado)
        {
            return await _context.Cooperados.Where(e => e.Id == idCooperado).FirstOrDefaultAsync();
        }

    }
}
