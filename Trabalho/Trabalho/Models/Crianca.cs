using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho.Models
{
    public class Crianca
    {
        public int CriancaId { get; set; }

        [Required]
        [Range(1, 25)]
        public int Idade { get; set; }

        [Required]
        public string Nome { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        

        public virtual Candidatura Candidatura { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? CandidaturaId { get; set; }

        


        //public virtual Instituicao Instituicao { get; set; }
        //public int? InstituicaoId { get; set; }
    }

}