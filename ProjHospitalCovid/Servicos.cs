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
            Paciente aux = filanormal.Pop();
            Console.WriteLine(aux.ToString());
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
