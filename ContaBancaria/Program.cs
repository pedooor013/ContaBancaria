using System;

namespace ContaBancaria
{
    class Program
    {
        public static List<ContaBancaria> contas = new List<ContaBancaria>();

        static void Main(string[] args)
        {
            LogicaExibicaoMenu(contas);
        }
        

        static void ExibirMenuSemConta()
        {
            Console.WriteLine("O que deseja fazer: " +
                              "\n01) Cadastrar conta;" +
                              "\n02) Sair;\n");
            int escolhaUser =  Convert.ToInt32(Console.ReadLine());
            EscolhaSemConta(escolhaUser);
        }

        static void ExibirMenuComConta()
        {
            Console.WriteLine("O que deseja fazer:" +
                              "\n01) Exibir informações da conta;" +
                              "\n02) Exibir o saldo;" +
                              "\n03) Depositar;" +
                              "\n04) Sacar;" +
                              "\n05) Sair;\n");
            int escolhaUser = Convert.ToInt32(Console.ReadLine());
            EscolhaComConta(escolhaUser);
        }

        private static void LogicaExibicaoMenu(List<ContaBancaria> contas)
        {
            if (contas.Count == 0)
            {
                ExibirMenuSemConta();
            }
            else
            {
                ExibirMenuComConta();
            }
        }

        static void EscolhaSemConta(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    CriarConta();
                    break;
                case 2:
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite novbamente!");
                    LogicaExibicaoMenu(contas);
                    break;
            }
        }

        static void CriarConta()
        {
            Console.WriteLine("Digite o numero da conta: ");
            string numeroConta = Console.ReadLine();

            Console.WriteLine("Digite o nome do titular da conta: ");
            string nomeTitular = Console.ReadLine();
            
            contas.Add(new ContaBancaria(numeroConta,  nomeTitular));
            LogicaExibicaoMenu(contas);
        }

        static void EscolhaComConta(int escolha)
        {
            switch (escolha)
            {
                case 1:
                    ExibirInformacoes();
                    break;
                case 2:
                    ExibirSaldo();
                    break;
                case 3:
                    RealizarDeposito();
                    break;
                case 4:
                    RealizarSaque();
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Digite novamente!");
                    LogicaExibicaoMenu(contas);
                    break;
            }
        }
        
        static void ExibirInformacoes()
        {
            Console.WriteLine($"Informações da conta:" +
                              $"\nNome: {contas[0].NomeTitular}" +
                              $"\nNº Conta: {contas[0].NumeroConta}" +
                              $"\nSaldo: {contas[0].ExibirSaldo().ToString("C")}\n");
            LogicaExibicaoMenu(contas);
        }

        static void ExibirSaldo()
        {
            Console.WriteLine($"Saldo em conta: {contas[0].ExibirSaldo().ToString("C")}\n");
            LogicaExibicaoMenu(contas);
        }

        static void RealizarDeposito()
        {
            Console.WriteLine("Digite o valor para deposito: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            
            contas[0].RealizarDeposito(valor);
            LogicaExibicaoMenu(contas);
        }

        static void RealizarSaque()
        {
            Console.WriteLine("Digite o valor para saque: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            
            contas[0].RealizarSaque(valor);
            LogicaExibicaoMenu(contas);
        }
        
    }
}