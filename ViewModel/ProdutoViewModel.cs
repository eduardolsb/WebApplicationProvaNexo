using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProvaNexo.ViewModel
{
    public class ProdutoViewModel
    {
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public double? Valor { get; set; }
        public bool? Disponivel { get; set; }
        public long ClienteId { get; set; }

        public ProdutoViewModel() { 
        
        }

        public ProdutoViewModel(Models.Produto produto)
        {
            
            ProdutoId = produto.ProdutoId;
            Nome = produto.Nome;
            Valor = produto.Valor;
            Disponivel = produto.Disponivel;
            ClienteId = produto.ClienteId;
            
        }
    }
}