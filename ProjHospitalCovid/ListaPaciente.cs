using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class ListaPaciente
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        public ListaPaciente()
        {
            Head = Tail = null;
        }

        public bool ListaPacienteVazia()
        {
            if (Head == null & Tail == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AdicionarPacienteNaLista(Paciente paciente)
        {
            if (ListaPacienteVazia())
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

        public void MostrarPacientesNaListaPacientes()
        {
            if (ListaPacienteVazia())
            {
                Console.WriteLine("Nenhum Paciente Na Lista");
            }
            else
            {
                Paciente paciente = Head;
                do
                {
                    Console.WriteLine(paciente.DadosCompletos());
                    paciente = paciente.Proximo;
                } while (paciente != null);
            }
        }
    }
}
