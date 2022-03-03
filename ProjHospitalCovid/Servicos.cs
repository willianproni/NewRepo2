using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class Servicos
    {
        public FilaNormal filanormal = new FilaNormal();
        public FilaPreferencial filapreferencial = new FilaPreferencial();


        int cont = 1;

        public Paciente CadastrarPaciente()
        {
            //VerificarExistenciaCadastro();
            {
                Console.WriteLine("\n\t\t--->> Cadastro de Pacientes <---");
                Console.Write("\n\t\tNome do Paciente: ");
                string nome = Console.ReadLine();
                Console.Write("\n\t\tQual o Sexo do paciente: ");
                char sexo = char.Parse(Console.ReadLine());
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
            if (filanormal.FilaNormalVazia() && filapreferencial.FilaPreferencialVazia())
            {
                Console.WriteLine("Nenhum Paciente esperando!!");
            }
            else if (filapreferencial.FilaPreferencialVazia() || ContChamadaTriagem())
            {
                Paciente pacienteNormal = filanormal.Pop();
                Console.WriteLine(pacienteNormal.DadosBasicos());

                filanormal.InserirPacienteFilaNormal(EntradaDadosTriagem(pacienteNormal));
            }
            else
            {
                Paciente pacientePreferencial = filapreferencial.Pop();
                Console.WriteLine(pacientePreferencial.DadosBasicos());

                filapreferencial.InserirPacienteFilaPreferencial(EntradaDadosTriagem(pacientePreferencial));
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

            Console.Write("\nSaturação do Paciente: ");
            paciente.Triagem.Saturacao = int.Parse(Console.ReadLine());
            SaturacaoBaixa(paciente.Triagem.Saturacao);

            Console.WriteLine("\nPossui Comorbudade: ");
            string possuiComorbidade = Console.ReadLine();
            paciente.Triagem.PossuiComorbidade = possuiComorbidade == "sim" || possuiComorbidade == "s" ? true : false;

            Console.WriteLine("\nDias dos sintomas: ");
            paciente.Triagem.DiasSintomas = int.Parse(Console.ReadLine());
            VerificarQuantidadeDiasSintomas(paciente.Triagem.DiasSintomas);

            return paciente;
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

        public void SaturacaoBaixa(int saturacao)
        {
            if (saturacao <= 90)
            {
                Console.WriteLine("Saturação do Paciente está abaixo de 90 ## Emergência #");
            }
            else
            {
                Console.WriteLine("Saturação acima de 90, Normal");
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
