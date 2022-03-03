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
        public Triagem Triagem { get; set; }

        public Paciente()
        {
            Triagem = new Triagem();
        }

        public Paciente(string nome, char sexo, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Triagem = new Triagem();
        }

        public Paciente(string nome, char sexo, DateTime dataNascimento, string cpf, Triagem triagem)
        {
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Triagem = new Triagem();
        }

        public string DadosBasicos()
        {
            return $"\nNome: {Nome}" +
                   $"\nSexo {Sexo}" +
                   $"\nData Nascimento {DataNascimento.ToString("dd/MM/yyyy")}" +
                   $"\nCpf: {Cpf}"; 
        }
        public string DadosCompletos()
        {
            return $"\nNome: {Nome}" +
                   $"\nSexo {Sexo}" +
                   $"\nData Nascimento {DataNascimento}" +
                   $"\nCpf: {Cpf}" +
                   $"\nDados Triagem: {Triagem.DadosTriagem()}";
        }
    }
}
