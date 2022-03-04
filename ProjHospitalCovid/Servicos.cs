using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;
using ProjHospitalCovid.Filas;

namespace ProjHospitalCovid
{
    internal class Servicos
    {
        public FilaNormal filaNormal = new FilaNormal();
        public FilaPreferencial filaPreferencial = new FilaPreferencial();
        public ListaPaciente listaPaciente = new ListaPaciente();
        public Leitos leitosVerifica = new Leitos();
        public FilaEsperaInternacao FilaEsperaInternacao = new FilaEsperaInternacao();
        public ListaInternados ListaInternados = new ListaInternados();


        int cont = 1;

        public Paciente CadastrarPaciente()
        {
            //VerificarExistenciaCadastro();
            {
                Console.WriteLine("\n\t\t--->> Cadastro de Pacientes <---");
                Console.Write("\n\t\tNome do Paciente: ");
                string nome = Console.ReadLine();
                Console.Write("\n\t\tQual o Sexo do paciente\n\t\tM - Masculino\n\t\tF - Feminino\n");
                Console.Write("\t\tSexo: ");
                char sexo = char.Parse(Console.ReadLine().ToUpper());
                Console.Write("\n\t\tData de Nascimento: ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                Console.Write("\n\t\tDigite o Cpf do Paciente: ");
                string cpf = Console.ReadLine();
                return new Paciente(nome, sexo, dataNascimento, cpf);
            }
        }

        public bool VerificarPreferenciaDeFila(Paciente paciente)
        {
            if (paciente.Idade >= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* public void InserirPacienteNaFila(Paciente paciente)
         {

             if (VerificarPreferenciaDeFila(paciente))
             {
                 filapreferencial.InserirPacienteFilaPreferencial(paciente);
             }
             else
             {
                 filanormal.InserirPacienteFilaNormal(paciente);
             }
             //armazenar.RegistrarPessoa(paciente);
         }*/

        public void ChamarPacienteTriagem()
        {
            if (filaNormal.FilaNormalVazia() && filaPreferencial.FilaPreferencialVazia())
            {
                Console.WriteLine("Nenhum Paciente esperando!!");
            }
            else if (filaPreferencial.FilaPreferencialVazia() || ContChamadaTriagem())
            {
                Paciente pacienteNormal = filaNormal.Pop();
                Console.WriteLine(pacienteNormal.DadosBasicos());

                listaPaciente.AdicionarPacienteNaLista(EntradaDadosTriagem(pacienteNormal));
            }
            else
            {
                Paciente pacientePreferencial = filaPreferencial.Pop();
                Console.WriteLine(pacientePreferencial.DadosBasicos());

                listaPaciente.AdicionarPacienteNaLista(EntradaDadosTriagem(pacientePreferencial));
                cont++;
            }
        }
        public bool ContChamadaTriagem()
        {
            if (cont > 2)
            {
                cont = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Paciente EntradaDadosTriagem(Paciente paciente)
        {
            Console.Write("\nPressão do Paciente: ");
            paciente.Triagem.Pressao = double.Parse(Console.ReadLine());
            PressaoAlta(paciente.Triagem.Pressao);

            Console.Write("\nTemperatura do Paciente: ");
            paciente.Triagem.Temperatura = double.Parse(Console.ReadLine());
            FebreAlta(paciente.Triagem.Temperatura);

            Console.Write("\nBatimentos Cardíacos do Paciente: ");
            paciente.Triagem.Batimentos = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPossui Comorbudade: ");
            string possuiComorbidade = Console.ReadLine();
            paciente.Triagem.PossuiComorbidade = possuiComorbidade == "sim" || possuiComorbidade == "s" ? true : false;

            Console.Write("\nSaturação do Paciente: ");
            paciente.Triagem.Saturacao = int.Parse(Console.ReadLine());
            SaturacaoBaixa(paciente.Triagem.Saturacao);


            Console.WriteLine("\nDias dos sintomas: ");
            paciente.Triagem.DiasSintomas = int.Parse(Console.ReadLine());
            VerificarQuantidadeDiasSintomas(paciente.Triagem.DiasSintomas);

            Console.WriteLine("--->> Sintomas do paciente <<---");

            Console.Write("[1] -  Falta de Ar ( s/n )");
            string faltaAr = Console.ReadLine();
            paciente.Triagem.Sintomas.FaltaAr = faltaAr == "s" ? true : false;

            Console.Write("[2] -  Dor no Peito ( s/n )");
            string dorPeito = Console.ReadLine();
            paciente.Triagem.Sintomas.DorPeito = dorPeito == "s" ? true : false;

            Console.Write("[3] - Perda Motora ( s/n )");
            string perdaMotora = Console.ReadLine();
            paciente.Triagem.Sintomas.PerdaMotora = perdaMotora == "s" ? true : false;

            Console.Write("[4] - Perda Paladar ( s/n )");
            string perdaPaladar = Console.ReadLine();
            paciente.Triagem.Sintomas.PercaPaladar = perdaPaladar == "s" ? true : false;

            Console.Write("[5] - Perda Olfato ( s/n )");
            string perdaOlfato = Console.ReadLine();
            paciente.Triagem.Sintomas.PercaOlfato = perdaOlfato == "s" ? true : false;

            if (SaturacaoBaixa(paciente.Triagem.Saturacao))
            {
                Console.WriteLine("Paciente apresenta estado Saturação baixo, Precisa ser Internado");
                if (leitosVerifica.PossuiVaga())
                {
                    Console.WriteLine("Leito Disponivel!!");
                    leitosVerifica.LeitosOcupados++;
                    paciente.Internado = PacienteEstaInternado();
                    ListaInternados.InserirPacienteInternacao(paciente);
                    Console.WriteLine("Paciente Internado");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Leitos Cheios, Paciente Adicionado em Uma fila de Espera");
                    FilaEsperaInternacao.AdicionarPacienteFilaEspera(paciente);
                    Console.ReadKey();
                }
            }

            else if (paciente.Triagem.PacienteVaiFazerTesteCovid())
            {
                Console.WriteLine("Realizou o Teste");
                Console.Write("Positivo ou Negativo (P ou N)");
                string resultado = Console.ReadLine().ToUpper();
                if (ResultadoRetornouPositivo(resultado))
                {
                    Console.WriteLine("O paciente vai ser Internado? : ");
                    char internar = char.Parse(Console.ReadLine().ToUpper());
                    if (internar == 'S')
                    {
                        if (leitosVerifica.PossuiVaga())
                        {
                            Console.WriteLine("Leito Disponivel!!");
                            leitosVerifica.LeitosOcupados++;
                            paciente.Internado = PacienteEstaInternado();
                            ListaInternados.InserirPacienteInternacao(paciente);
                            Console.WriteLine("Paciente Internado");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Leitos Cheios, Paciente Adicionado em Uma fila de Espera");
                            FilaEsperaInternacao.AdicionarPacienteFilaEspera(paciente);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("O paciente vai Cumprir quarentena de 15 Dias");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Teste de Negativo, Paciente Dispenasado e Registrado");
                }
            }
            else
            {
                Console.WriteLine("Dispensado e Registrado no Sistema");
            }
            return paciente;
        }
        public bool ResultadoRetornouPositivo(string resultado)
        {
            if (resultado == "P")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool PacienteEstaInternado()
        {
            return true;
        }

        public void PressaoAlta(double pressao)
        {
            if (pressao > 14.9)
            {
                Console.WriteLine("Pressão do Paciente está alta");
            }
            else
            {
                Console.WriteLine("Pressão do Paciente está Normal");
            }
        }

        public void FebreAlta(double temperatura)
        {
            if (temperatura < 37.3)
            {
                Console.WriteLine("Paciente está sem Febre");
            }
            else if (temperatura >= 37.3 && temperatura <= 37.8)
            {
                Console.WriteLine("Paciente está com Febre");
            }
            else if (temperatura > 37.8)
            {
                Console.WriteLine("Paciente está com Febre Alta");
            }
            {

            }
        }

        public bool SaturacaoBaixa(int saturacao)
        {
            if (saturacao <= 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VerificarQuantidadeDiasSintomas(int diasSintomas)
        {
            if (diasSintomas >= 3)
            {
                Console.WriteLine("Prosseguir com o Teste");
            }
            else
            {
                Console.WriteLine("Dispensar Paciente, Solicitar Retorno");
            }
        }
    }
}
