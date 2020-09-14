using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProvaNexo.Models;

namespace WebApplicationProvaNexo.ViewModel
{
    public class ClienteViewModel
    {
        public long ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool? Ativo { get; set; }


        public List<ViewModel.ProdutoViewModel> Produtos { get; set; }

        public ClienteViewModel()
        {
            
        }

        public ClienteViewModel(Models.Cliente cliente)
        {
            Context db = new Context();

            
            ClienteId = cliente.ClienteId;
            Nome = cliente.Nome;
            SobreNome = cliente.SobreNome;
            Email = cliente.Email;
            DataCadastro = cliente.DataCadastro;
            Ativo = cliente.Ativo;

            var _produtos = db.Produtos.Where(a => a.ClienteId == cliente.ClienteId).ToList();

            Produtos = (_produtos.Any()) ? _produtos.Select(a => new ViewModel.ProdutoViewModel(a)).ToList() : null;

            Tipo = TipoCliente(cliente, _produtos);
            
        }

        private string TipoCliente(Models.Cliente cliente, List<Produto> produto)
        {
            var _tipo = "";

            if((DateTime.Now - cliente.DataCadastro.Value).TotalDays >= (365 * 5))
            {
                _tipo = "Prata";
            }

            if (produto != null)
            {
                if (produto.Count() >= 2000 && produto.Count() < 5000)
                {
                    _tipo = "Ouro";
                }
                else if (produto.Count() >= 5000 && produto.Count() < 10000)
                {
                    _tipo = "Platina";
                }
                else if (produto.Count() >= 10000)
                {
                    _tipo = "Diamante";
                }
            }

            if(cliente.Ativo == false)
            {
                _tipo = "";
            }

            return _tipo;
        }
    }
}