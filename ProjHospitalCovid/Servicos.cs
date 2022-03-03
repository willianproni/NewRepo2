using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class Servicos
    {
        FilaNormal filanormal = new FilaNormal();
        FilaPreferencial filapreferencial = new FilaPreferencial();
        int cont = 1;

        public Paciente CadastrarPaciente()
        {
            //VerificarExistenciaCadastro();
            {
                Console.WriteLine("Nome do Paciente");
                string nome = Console.ReadLine();
                Console.WriteLine("Qual o Sexo do paciente ");
                char sexo = char.Parse(Console.ReadLine());
                Console.WriteLine("Data de Nascimento: ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Cpf do Paciente: ");
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

        public void InserirPacienteNaFila(Paciente paciente)
        {

            if (VerificarPreferenciaDeFila(paciente))
            {
                filapreferencial.InserirPacienteFilaPreferencial(paciente);
            }
            else
            {
                filanormal.InserirPacienteFilaNormal(paciente);
            }
        }

        public void ChamarPacienteTriagem()
        {
            if (VerificarFilaDeTriagemVazia())
            {
                Console.WriteLine("Nenhum Paciente no momento");
            }
            else if (filapreferencial.FilaPreferencialVazia())
            {
                Console.WriteLine("Sim");
            }
            else
            {
                if (ContChamadaTriagem())
                {
                    Paciente aux = filapreferencial.Head;
                }
            }

        }

        public bool VerificarFilaDeTriagemVazia()
        {
            if (filanormal.FilaNormalVazia() && filapreferencial.FilaPreferencialVazia())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContChamadaTriagem()
        {
            if (cont >= 2)
            {
                return true;
            }
            else
            {
                cont = 1;
                return false;
            }
        }

    }
}
