using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Interfaces.Repositories;
using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using DesafioAxisRefactor.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxisRefactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperadoController : ControllerBase
    {
        private readonly ICooperadoRepository _repository;
        public CooperadoController(ICooperadoRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllCooperados()
        {
            try
            {
                List<Cooperado> cooperados = await _repository.GetAllCooperados();
                int tam = cooperados.Count();

                return Ok(new
                {
                    data = cooperados,
                    success = true,
                    message = tam + " itens retornados"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }
        }

        //[HttpGet("id")]
        //public async Task<ActionResult> GetCooperadoById([FromRoute] int id)
        //{
        //    try
        //    {
        //        Cooperado cooperado = await _repository.GetCooperadoById(id);
        //        return Ok(new
        //        {
        //            data = cooperado,
        //            success = true,
        //            message =  "Item encontrado com sucesso"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            data = ex.Data,
        //            success = false,
        //            message = ex.Message
        //        });
        //    }
        //}

        [HttpPost("{idCooperado}/Create-favorito")]
        public async Task<ActionResult> CreateFavoritoByCooperador([FromRoute] int idCooperado, CreateFavoritoDataTransfer favorito)
        {
            try
            {
                await _repository.CreateFavoritoCooperado(idCooperado, favorito);
                return Ok(new
                {
                    data = favorito,
                    success = true,
                    message = "Item criado com sucesso!"
                });
            }
            catch
            {
                return BadRequest();
            }
      
        }

    }
}
