using DesafioAxisRefactor.Domain.DataTransaferes;
using DesafioAxisRefactor.Domain.Models;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.Services.Validation
{
    public class CooperativaValidation : ICooperativaValidation
    {
        public bool RequestBodyValidation(CreateCooperativaDataTransfer cooperativa)
        {
            if (cooperativa.Description == null || cooperativa.Description == "" || cooperativa.Description == "string")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
