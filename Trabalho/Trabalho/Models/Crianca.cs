using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho.Models
{
    public class Crianca
    {
        public int CriancaId { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        

        public virtual Instituicao Instituicao { get; set; }
        public int InstituicaoId { get; set; }
    }
}