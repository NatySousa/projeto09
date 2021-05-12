using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto09.Entities
{
    public class Produto
    {
        //propriedades -> prop + 2x[tab]
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
