using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using DesafioAxisRefactor.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxisRefactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperativasController : ControllerBase
    {
        private readonly DesafioAxisRefactorContext _context;
        private readonly ICooperativaValidation _validation;
        public CooperativasController(DesafioAxisRefactorContext context, ICooperativaValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        [HttpGet]
        public async Task<ActionResult> GetCoperativas()
        {
            try
            {
                List<Cooperativas> res = await _context.Cooperativas.ToListAsync();
                int tam = res.Count();

                return Ok(new
                {
                    data = res,
                    success = true,
                    message = tam + " itens retornados"
                });
            }catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCooperativas(Cooperativas cooperativas)
        {
            try
            {
                bool isValid = _validation.RequestBodyValidation(cooperativas);
                if (!isValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Foi encontrado um erro de validação"
                    });
                }
                await _context.Cooperativas.AddAsync(cooperativas);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    data = cooperativas,
                    success = true,
                    message = "Item criado com sucesso!"
                });
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }


        }

    }
}
