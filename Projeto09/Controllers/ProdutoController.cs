using Projeto09.Entities;
using ProjetoAula09.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto09.Controllers
{
    public class ProdutoController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjeto09;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //método para realizar o cadastro do produto
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE PRODUTO\n");

                var produto = new Produto();

                Console.Write("Entre com o nome do produto........: ");
                produto.Nome = Console.ReadLine();

                Console.Write("Entre com o preço do produto.......: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Entre com a quantidade do produto..: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("Entre com a data de validade.......: ");
                produto.DataValidade = DateTime.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                //gravar o produto no banco de dados
                produtoRepository.Inserir(produto);

                Console.WriteLine("\nProduto cadastrado com sucesso.");

            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO\n");

                Console.Write("Informe o ID do Produto: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produto =  produtoRepository.ObterPorId(idProduto);

                //verificando se o produto foi encontrado
                if (produto != null)
                {
                    Console.Write("Nome do produto........: ");
                    produto.Nome = Console.ReadLine();

                    Console.Write("Preço do produto.......: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());

                    Console.Write("Quantidade do produto..: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Data de validade.......: ");
                    produto.DataValidade = DateTime.Parse(Console.ReadLine());

                    //atualizando o  produto
                    produtoRepository.Atualizar(produto);

                    Console.WriteLine("\nProduto atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE PRODUTO\n");

                Console.Write("Informe o ID do Produto: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produto = produtoRepository.ObterPorId(idProduto);

                //verificando se o produto foi encontrado
                if (produto != null)
                {
                    //excluindo o produto
                    produtoRepository.Excluir(produto);

                    Console.WriteLine("\nProduto excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nProdutonão encontrado.Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ConsultarProdutos()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE PRODUTOS\n");

                var produtoRepository = new ProdutoRepository();
                produtoRepository.ConnectionString = connectionString;

                var produto = produtoRepository.ObterTodos();

                foreach (var item in produto)
                {
                    Console.WriteLine("Id do Produto...: " + item.IdProduto);
                    Console.WriteLine("Nome................: " + item.Nome);
                    Console.WriteLine("Preço.................: " + item.Preco);
                    Console.WriteLine("Quantidade...........: " + item.Quantidade);
                    Console.WriteLine("Data de validade....: " + item.DataValidade.ToString("dddd, dd/MM/yyyy"));

                    Console.WriteLine("---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }
    }
}


