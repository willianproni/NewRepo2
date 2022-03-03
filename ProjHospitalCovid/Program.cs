using System;

namespace ProjHospitalCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao, cont = 1;
            Servicos servicos = new Servicos();
            Armazenar armazenar = new Armazenar();

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
                        Console.WriteLine($"\t\t\tSenha Número {cont}");
                        cont++;
                        Paciente paciente = servicos.CadastrarPaciente();
                        if (servicos.VerificarPreferenciaDeFila(paciente))
                        {
                            servicos.filapreferencial.InserirPacienteFilaPreferencial(paciente);
                            Console.WriteLine("Fila Preferencial");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            servicos.filanormal.InserirPacienteFilaNormal(paciente);
                            Console.WriteLine("\n\t\t --->> Fila Normal <<---");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        servicos.filanormal.ExibirFilaNormal();
                        break;
                    case 3:
                        servicos.filapreferencial.ExibirFilaPreferencial();
                        break;
                    case 4:
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
                              "\n[2] - Exibir Fila Normal" +
                              "\n[3] - Exibir Fila Prioridade" +
                              "\n[4] - Alta em Paciente" +
                              "\n[0] - Fechar Sistema");
        }
    }
}
