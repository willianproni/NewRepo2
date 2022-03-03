using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class Paciente
    {
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public int Idade => (DateTime.Now - DataNascimento).Days / 365;
        public Paciente Proximo { get; set; }

        public Paciente()
        {

        }

        public Paciente(string nome, char sexo, DateTime datanascimento, string cpf)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = datanascimento;
            Cpf = cpf;
        }

        public override string ToString()
        {
            return $"\nNome: {Nome}" +
                   $"\nSexo {Sexo}" +
                   $"\nData Nascimento {DataNascimento}" +
                   $"\nCpf: {Cpf}"; 
        }
    }
}
