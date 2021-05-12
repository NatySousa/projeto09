using Projeto09.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto09.Interfaces
{
    public interface IProdutoRepository
    {
        void Inserir(Produto produto);

        void Atualizar(Produto produto);

        void Excluir(Produto produto);

        List<Produto> ObterTodos();

        Produto ObterPorId(Guid idProduto);
    }
}
