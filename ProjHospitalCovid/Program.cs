using System;

namespace ProjHospitalCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao, cont = 1;
            Servicos servicos = new Servicos();
            do
            {
                Menu();
                opcao = int.Parse(Console.ReadLine());  
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Fechando...");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"\tSenha Número {cont}");
                        cont++;
                        Console.ReadKey();
                        servicos.InserirPacienteNaFila(servicos.CadastrarPaciente());
                        break;
                    case 3:
                        servicos.ChamarPacienteTriagem();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (opcao != 0);
        }
        public static void Menu()
        {
            Console.WriteLine("\n[1] - Cadastrar Paciente" +
                              "\n[2] - Buscar Cadastro" +
                              "\n[3] - Chamar para Triagem" +
                              "\n[4] - Alta em Paciente" +
                              "\n[0] - Fechar Sistema");
        }
    }
}
