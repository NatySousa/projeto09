using Projeto09.Controllers;
using System;

namespace Projeto09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE PRODUTOS\n");

            var produtoController = new ProdutoController();

            Console.WriteLine("(1) Cadastrar produto");
            Console.WriteLine("(2) Atualizar produto");
            Console.WriteLine("(3) Excluir produto");
            Console.WriteLine("(4) Consultar produto");
            Console.WriteLine("(0) Sair");

            try
            {
                Console.Write("\nEscolha a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        Main(args); //recursividade
                        break;

                    case 2:
                        produtoController.AtualizarProduto();
                        Main(args); //recursividade(looping)
                        break;

                    case 3:
                        produtoController.ExcluirProduto();
                        Main(args);
                        break;

                    case 4:
                        produtoController.ConsultarProdutos();
                        Main(args);
                        break;


                    case 0:
                        Console.WriteLine("\nFIM DO PROGRAMA!");
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
