using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid
{
    internal class FilaPreferencial
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        public FilaPreferencial()
        {
            Head = Tail = null;
        }

        public bool FilaPreferencialVazia()
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

        public void InserirPacienteFilaPreferencial(Paciente novopreferencial)
        {
            if (FilaPreferencialVazia())
            {
                Head = novopreferencial;
                Tail = novopreferencial;
            }
            else
            {
                Tail.Proximo = novopreferencial;
                Tail = novopreferencial;
            }
        }
        public void ExibirFilaPreferencial()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t---> Fila Preferencial <---\n");
            if (FilaPreferencialVazia())
            {
                Console.WriteLine("\t\tNenhum Paciente na Fila de Prioridade");
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
            if (FilaPreferencialVazia())
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
