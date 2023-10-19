using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Interfaces.Repositories;
using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAxisRefactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {

        //private readonly ICooperativaValidation _validation;
        private readonly IFavoritosRepository _repository;
        public FavoritosController(IFavoritosRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllFavoritos()
        {
            try
            {
                List<Favorito> favoritos = await _repository.GetAllFavoritos();
                int tam = favoritos.Count();

                return Ok(new
                {
                    data = favoritos,
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
        //        Favorito favorito = await _repository.GetFavoritoById(id);
        //        return Ok(new
        //        {
        //            data = favorito,
        //            success = true,
        //            message = "Item encontrado com sucesso"
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

        [HttpGet("{idCooperado}/Get-all-by-id")]
        public async Task<ActionResult> GetAllFavoritosFromCooperado([FromRoute] int idCooperado)
        {
            try
            {
                List<Favorito> favoritos = await _repository.GetAllFavoritosFromCooperado(idCooperado);
                int tam = favoritos.Count();

                return Ok(new
                {
                    data = favoritos,
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

        [HttpDelete]
        public async Task<ActionResult> DeletFavorito([FromRoute] int idFavorito)
        {
            try
            {
                await _repository.DeleteFavorito(idFavorito);
                return Ok(new
                {
                    data = "",
                    success = true,
                    message ="Item Removido"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    data = ex.Data,
                    success = false,
                    message = ex.Message
                });
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateFavorito([FromRoute] int idFavorito,
            UpdateFavoritoDataTransfer updateFavoritoDataTransfer)
        {
            try
            {
                await _repository.UpdateFavorito(idFavorito, updateFavoritoDataTransfer);
                return Ok(new
                {
                    data = updateFavoritoDataTransfer,
                    success = true,
                    message = "Item Removido"
                });
            }
            catch(Exception ex)
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
