using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho.Models
{
    public class Candidatura
    {
        public int CandidaturaId { get; set; }

        public string Estado { get; set; }

        [DisplayName("Criança Concorrente")]
        public int CriancaId { get; set; }

        [DisplayName("Instituição Concorrida")]
        public int InstituicaoId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [NotMapped]
        public string NomeInstituicao { get; set; }

        [NotMapped]
        public string NomeCrianca { get; set; }
    }
}