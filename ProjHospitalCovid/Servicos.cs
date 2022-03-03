using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class Servicos
    {
        public void CadastrarPaciente()
        {
            Console.WriteLine("Nome do Paciente");
            string nome = Console.ReadLine();
            Console.WriteLine("Qual o Sexo do paciente ");
            char sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Data de Nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Cpf do Paciente: ");
            string cpf = Console.ReadLine();
        }
    }
}
