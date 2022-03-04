using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid.Filas
{
    internal class ListaInternados
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        public ListaInternados()
        {
            Head = Tail = null;
        }

        public bool ListaInternadosVazia()
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

        public void InserirPacienteInternacao(Paciente paciente)
        {
            if (ListaInternadosVazia())
            {
                Head = paciente;
                Tail = paciente;
            }
            else
            {
                Tail.Proximo = paciente;
                Tail = paciente;
            }
        }

        public void ExibirPacientesInternados()
        {
            if (ListaInternadosVazia())
            {
                Console.WriteLine("Nenhum Paciente internado Que bom :)");
            }
            Paciente paciente = Head;
            do
            {
                Console.WriteLine(paciente.DadosCompletos());
                paciente = paciente.Proximo;
            } while (paciente != null);
        }

        public void Alta(Paciente aux)
        {
            aux = null;

        }
    }
}
