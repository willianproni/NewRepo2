using System;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao, cont = 1, lista;
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
                        Console.WriteLine("##################\n" +
                                          $"# Senha Número {cont} #\n" +
                                          "##################");
                        cont++;
                        Paciente paciente = servicos.CadastrarPaciente();
                        if (servicos.VerificarPreferenciaDeFila(paciente))
                        {
                            servicos.filaPreferencial.InserirPacienteFilaPreferencial(paciente);
                            Console.WriteLine("\n\t\t Adicionado Fila Preferencial <<---");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            servicos.filaNormal.InserirPacienteFilaNormal(paciente);
                            Console.WriteLine("\n\t\t Adicionado Fila Normal <<---");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        servicos.ChamarPacienteTriagem();
                        break;
                    case 3:
                        //servicos.AltaEmPacienteInternado(); //Esta entrando em Loop (Já sei arrumar)!
                        break;
                    case 4:
                        do
                        {
                            MenuLista();
                            lista = int.Parse(Console.ReadLine());
                            switch (lista)
                            {
                                case 1:
                                    servicos.filaNormal.ExibirFilaNormal();
                                    break;
                                case 2:
                                    servicos.filaPreferencial.ExibirFilaPreferencial();
                                    break;
                                case 3:
                                    servicos.listaPaciente.MostrarPacientesNaListaPacientes();
                                    break;
                                case 4:
                                    servicos.ListaInternados.ExibirPacientesInternados();
                                    break;
                                case 5:
                                    servicos.FilaEsperaInternacao.ExibirPacientesFilaEspera();
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("Digite Uma opção Válida!");
                                    break;
                            }
                        } while (lista != 6);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (opcao != 0);
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t\t-_-_-_-_-_-_-_Covidário_-_-_-_-_-_-_-");
            Console.WriteLine("\n\t\t[1] - Cadastrar Paciente" +
                              "\n\t\t[2] - Chamar Paciente para Triagem" +
                              "\n\t\t[3] - Realizar Alta de Paciente" +
                              "\n\t\t[4] - Verificar Pacietes por Listas e Filas" +
                              "\n\t\t[0] - Fechar Sistema" +
                              "\n\t\t------------------------------------");
            Console.Write("\t\tOpção: ");
        }

        public static void MenuLista()
        {

            Console.WriteLine("\t\t-_-_-_-Verificar andamentos das Listas-_-_-_-\n" +
                              "\n\t\t[1] - Fila Pacientes Normal" +
                              "\n\t\t[2] - Fila Pacientes Preferencial" +
                              "\n\t\t[3] - Lista de Todos os Pacientes" +
                              "\n\t\t[4] - Mostrar Pacientes Internados" +
                              "\n\t\t[5] - Fila de espera internação" +
                              "\n\t\t[6] - Voltar" +
                              "\n\t\t------------------------------------");
            Console.Write("\t\tOpção: ");
        }
    }
}
