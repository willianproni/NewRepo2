﻿using System;
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
                Console.Write("\n\t\tData de Nascimento (dd/mm/yyyy): ");
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
            Console.Clear();
            if (filaNormal.FilaNormalVazia() && filaPreferencial.FilaPreferencialVazia())
            {
                Console.WriteLine("\t\tNenhum Paciente esperando!!");
                Console.ReadKey();
                Console.Clear();
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

        public void AltaEmPacienteInternado()
        {
            if (ListaInternados.ListaInternadosVazia())
            {
                Console.WriteLine("Nenhum paciente Internado");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o CPF do Paciente: ");
                string cpf = Console.ReadLine();

                Paciente aux = ListaInternados.Head;
                do
                {
                    if (aux.Cpf.CompareTo(cpf) == 0)
                    {
                        ListaInternados.RemoverInternação(aux);
                        leitosVerifica.LeitosOcupados++;
                    }
                    else
                    {
                        aux = aux.Proximo;
                    }
                } while (aux != null);
            }
        }

        public Paciente EntradaDadosTriagem(Paciente paciente)
        {
            Console.Write("\n\tPressão do Paciente: ");
            paciente.Triagem.Pressao = double.Parse(Console.ReadLine());
            PressaoAlta(paciente.Triagem.Pressao);

            Console.Write("\n\tTemperatura do Paciente: ");
            paciente.Triagem.Temperatura = double.Parse(Console.ReadLine());
            FebreAlta(paciente.Triagem.Temperatura);

            Console.Write("\n\tBatimentos Cardíacos do Paciente: ");
            paciente.Triagem.Batimentos = int.Parse(Console.ReadLine());

            Console.Write("\n\tPossui Comorbidade (s/n): ");
            string possuiComorbidade = Console.ReadLine();
            paciente.Triagem.PossuiComorbidade = possuiComorbidade == "sim" || possuiComorbidade == "s" ? true : false;
            if (paciente.Triagem.PossuiComorbidade == true)
            {
                Console.WriteLine("\n\t--->> Comorbidades Prejudiciais Covid <<---");

                Console.Write("\t[1] - Diabetes ( s/n ): ");
                string diabetes = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = diabetes == "s" ? true : false;

                Console.Write("\t[2] - Hipertensão ( s/n ): ");
                string hipertensao = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = hipertensao == "s" ? true : false;

                Console.Write("\t[3] - Câncer ( s/n ): ");
                string cancer = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = cancer == "s" ? true : false;

                Console.Write("\t[4] - Doenças Cardiovasculares ( s/n ): ");
                string doencacardiovascular = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = doencacardiovascular == "s" ? true : false;

                Console.Write("\t[5] - Doenças Pulmonares ( s/n ): ");
                string doencapulmao = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = doencapulmao == "s" ? true : false;

                Console.Write("\t[6] - Neurológicos ( s/n ): ");
                string neurologicos = Console.ReadLine();
                paciente.Triagem.Comorbidade.Diabetes = neurologicos == "s" ? true : false;
            }

            Console.Write("\n\tSaturação do Paciente: ");
            paciente.Triagem.Saturacao = int.Parse(Console.ReadLine());
            SaturacaoBaixa(paciente.Triagem.Saturacao);


            Console.Write("\n\tDias dos sintomas: ");
            paciente.Triagem.DiasSintomas = int.Parse(Console.ReadLine());
            if (VerificarQuantidadeDiasSintomas(paciente.Triagem.DiasSintomas))
            {
                Console.WriteLine("\n\t--->> Sintomas do paciente <<---");

                Console.Write("\t[1] - Falta de Ar ( s/n ): ");
                string faltaAr = Console.ReadLine();
                paciente.Triagem.Sintomas.FaltaAr = faltaAr == "s" ? true : false;

                Console.Write("\t[2] - Dor no Peito ( s/n ): ");
                string dorPeito = Console.ReadLine();
                paciente.Triagem.Sintomas.DorPeito = dorPeito == "s" ? true : false;

                Console.Write("\t[3] - Perda Motora ( s/n ): ");
                string perdaMotora = Console.ReadLine();
                paciente.Triagem.Sintomas.PerdaMotora = perdaMotora == "s" ? true : false;

                Console.Write("\t[4] - Perda Paladar ( s/n ): ");
                string perdaPaladar = Console.ReadLine();
                paciente.Triagem.Sintomas.PercaPaladar = perdaPaladar == "s" ? true : false;

                Console.Write("\t[5] - Perda Olfato ( s/n ): ");
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
                    Console.Write("\tPositivo ou Negativo (P ou N): ");
                    string resultado = Console.ReadLine().ToUpper();
                    if (ResultadoRetornouPositivo(resultado))
                    {
                        Console.Write("\tO paciente vai ser Internado? (s/n): ");
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
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Dispensado e Registrado no Sistema");
                }
            }
            return paciente;
        }

        public bool ResultadoRetornouPositivo(string resultado)
        {
            if (resultado == "P" || resultado == "POSITIVO")
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

        public bool PacienteTeveAlta()
        {
            return false;
        }

        public void PressaoAlta(double pressao)
        {
            if (pressao > 14.9)
            {
                Console.WriteLine("\tPressão do Paciente está alta");
            }
            else
            {
                Console.WriteLine("\tPressão do Paciente está Normal");
            }
        }

        public void FebreAlta(double temperatura)
        {
            if (temperatura < 37.3)
            {
                Console.WriteLine("\tPaciente está sem Febre");
            }
            else if (temperatura >= 37.3 && temperatura <= 37.8)
            {
                Console.WriteLine("\tPaciente está com Febre");
            }
            else if (temperatura > 37.8)
            {
                Console.WriteLine("\tPaciente está com Febre Alta");
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

        public bool VerificarQuantidadeDiasSintomas(int diasSintomas)
        {
            if (diasSintomas >= 3)
            {
                Console.WriteLine("\tProsseguir com o Teste");
                return true;
            }
            else
            {
                Console.WriteLine("\tDispensar Paciente, Solicitar Retorno");
                Console.ReadKey();
                return false;
            }
        }

        public Paciente[] ObterPacientesPorNomeCPF()
        {
            listaPaciente.ListaPacienteVazia();

            Console.Write("Digite o nome ou CPF do paciente para que seja localizado: ");
            Paciente[] pacientes = listaPaciente.BuscaPeloCPFNome(Console.ReadLine());

            if (pacientes == null)
                Console.WriteLine("Paciente não encontrado");
            else
            {
                foreach (Paciente paciente in pacientes)
                    if (paciente != null) Console.WriteLine(paciente.DadosCompletos());
            }
            return pacientes;

        }

        public Paciente DarAltaPaciente()
        {
            Paciente[] pacientes = ObterPacientesPorNomeCPF();

            if (pacientes == null)
            {
                return null;
            }
            else
            {
                pacientes[0].Internado = PacienteTeveAlta();
                ListaInternados.RemoverInternação(pacientes[0]);
                return pacientes[0];
            }
        }
    }
}
