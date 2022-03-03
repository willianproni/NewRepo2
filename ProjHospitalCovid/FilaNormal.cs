using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class FilaNormal
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }
        public FilaNormal Proximo { get; set; }

        public FilaNormal()
        {
            Head = Tail = null;
        }

        public bool FilaNormalVazia()
        {
            if (Head == null && Tail == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InserirPacienteFilaNormal(Paciente novonormal)
        {
            if (FilaNormalVazia())
            {
                Head = novonormal;
                Tail = novonormal;
            }
            else
            {
                Tail.Proximo = novonormal;
                Tail = novonormal;
            }
        }

        public void ExibirFilaNormal()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t---> Fila Normal <---\n");
            if (FilaNormalVazia())
            {
                Console.WriteLine("\t\tNenhum paciente na Fila Normal");
            }
            else
            {
                Paciente paciente = Head;
                do
                {
                    Console.WriteLine(paciente.DadosBasicos());
                    paciente = paciente.Proximo;
                } while (paciente != null);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public Paciente Pop()
        {
            Paciente antigo = Head;
            if (FilaNormalVazia())
            {
                return null;
            }
            else if (Head.Proximo == null)
            {
                Tail = Head = null;
            }
            else
            {
                Head = Head.Proximo;
            }
            antigo.Proximo = null;
            return antigo;
        }
    }
}
