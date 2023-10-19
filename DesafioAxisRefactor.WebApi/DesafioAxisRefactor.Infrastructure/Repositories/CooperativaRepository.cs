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
    public class CooperativaRepository : ICooperativaRepository
    {
        private readonly DesafioAxisRefactorContext _context;

        public CooperativaRepository(DesafioAxisRefactorContext context)
        {
                _context = context;
        }
        public async Task CreateCooperativa(CreateCooperativaDataTransfer cooperativa)
        {
            Cooperativa addCooperativa = new Cooperativa(cooperativa.Description);
            await _context.Cooperativas.AddAsync(addCooperativa);
            _context.SaveChanges();
        }
        public async Task CreateCooperadoByCooperativa(int idCooperativa, CreateCooperadoDataTransfer cooperado)
        {
            Cooperado addCooperado = new Cooperado(cooperado.Name, cooperado.ContaCorrente, idCooperativa);
            await _context.Cooperados.AddAsync(addCooperado);
            _context.SaveChanges(true);
        }
        public async Task<List<Cooperativa>> GetAllCoperativas()
        {
            return await _context.Cooperativas.ToListAsync();
        }

        public  Cooperativa GetCoperativaById(int idCooperativa)
        {
            return _context.Cooperativas.Where(e => e.Id == idCooperativa).FirstOrDefault();
        }
    }
}
