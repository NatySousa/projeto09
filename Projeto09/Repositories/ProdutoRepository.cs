using Dapper;
using Projeto09.Entities;
using Projeto09.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoAula09.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //prop + 2x[tab]
        public string ConnectionString { get; set; }

        public void Atualizar(Produto produto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_ATUALIZARPRODUTO",
                    new
                    {
                        @IDPRODUTO = produto.IdProduto,
                        @NOME = produto.Nome,
                        @PRECO = produto.Preco,
                        @QUANTIDADE = produto.Quantidade,
                        @DATAVALIDADE = produto.DataValidade
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Excluir(Produto produto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_EXCLUIRPRODUTO",
                    new
                    {
                        @IDPRODUTO = produto.IdProduto
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Inserir(Produto produto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_INSERIRPRODUTO",
                    new
                    {
                        @NOME = produto.Nome,
                        @PRECO = produto.Preco,
                        @QUANTIDADE = produto.Quantidade,
                        @DATAVALIDADE = produto.DataValidade
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Produto ObterPorId(Guid idProduto)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Produto>("SP_OBTERPRODUTOPORID",
                    new
                    {
                        @IDPRODUTO = idProduto
                    },
                    commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
        }

        public List<Produto> ObterTodos()
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Produto>("SP_OBTERPRODUTOS",
                    commandType: CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}


