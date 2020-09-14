using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProvaNexo.Models
{
    public class Produto
    {
        [Key]
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }
        public bool? Disponivel { get; set; }
        public long ClienteId { get; set; }
    }
}