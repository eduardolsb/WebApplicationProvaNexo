using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProvaNexo.Models
{
    public class Cliente
    {

        public Cliente()
        {
            this.Produtos = new List<Produto>();
        }

        [Key]
        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? Ativo { get; set; }


        //public IList<Produto> Produtos { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

    }
}