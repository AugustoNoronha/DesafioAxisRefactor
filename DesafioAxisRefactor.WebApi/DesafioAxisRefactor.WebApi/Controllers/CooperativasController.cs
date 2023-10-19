using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Interfaces.Repositories;
using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using DesafioAxisRefactor.Infrastructure.Data.Context;
using DesafioAxisRefactor.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioAxisRefactor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperativasController : ControllerBase
    {
        private readonly ICooperativaValidation _validation;
        private readonly ICooperativaRepository _repository;
        public CooperativasController(ICooperativaValidation validation, ICooperativaRepository repository)
        {
            _validation = validation;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCoperativas()
        {
            try
            {
                List<Cooperativa> cooperativas = await _repository.GetAllCoperativas();
                int tam = cooperativas.Count();

                return Ok(new
                {
                    data = cooperativas,
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
        //public Task<ActionResult> GetCooperadoById([FromRoute] int id)
        //{
         
        //        Cooperativa cooperativa =  _repository.GetCoperativaById(id);
        //    if(cooperativa != null)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest(new
        //        {
        //            data = ex.Data,
        //            success = false,
        //            message = ex.Message
        //        });
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> CreateCooperativas(CreateCooperativaDataTransfer cooperativa)
        {
            try
            {
                bool isValid = _validation.RequestBodyValidation(cooperativa);
                if (!isValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Foi encontrado um erro de validação"
                    });
                }

               await _repository.CreateCooperativa(cooperativa);

                return Ok(new
                {
                    data = cooperativa,
                    success = true,
                    message = "Item criado com sucesso!"
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

        [HttpPost("{idCooperativa}/Create-cooperado")]
        public async Task<ActionResult> CreateCooperadoByCooperativa([FromRoute] int idCooperativa, CreateCooperadoDataTransfer cooperado)
        {
            try
            {
                //bool isValid = _validation.RequestBodyValidation(cooperativa);
                //if (!isValid)
                //{
                    //return BadRequest(new
                    //{
                    //    success = false,
                    //    message = "Foi encontrado um erro de validação"
                    //});
                //}

                await _repository.CreateCooperadoByCooperativa(idCooperativa, cooperado);

                return Ok(new
                {
                    data = cooperado,
                    success = true,
                    message = "Item criado com sucesso!"
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

    }
}
