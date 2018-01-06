using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho.Models
{
    public class Instituicao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public bool Creche { get; set; }

        [Display(Name = "Pré-Escolar")]
        public bool PreEscolar { get; set; }

        [Display(Name = "Transporte de Crianças")]
        public bool TransporteCriancas { get; set; }

        [Display(Name = "Aulas de Natação")]
        public bool AulasNatacao { get; set; }

        [Display(Name = "Aulas de Música")]
        public bool AulasMusica { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        public virtual ICollection<Crianca> Criancas { get; set; }
        //public virtual UserViewModel Utilizador { get; set; }

    }
}