﻿using DesafioAxisRefactor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAxisRefactor.Domain.DataTransaferes
{
    public class UpdateFavoritoDataTransfer
    {
        public PixType PixType { get; set; }
        public string PixKey { get; set; } = string.Empty;
    }
}
