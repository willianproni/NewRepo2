using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid.Filas
{
    internal class FilaEsperaInternacao
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        public FilaEsperaInternacao()
        {
            Head = Tail = null;
        }

        public bool FilaDeEsperaInternacaoVazia()
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
        public void AdicionarPacienteFilaEspera(Paciente paciente)
        {
            if (FilaDeEsperaInternacaoVazia())
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

        public void ExibirPacientesFilaEspera()
        {
            if (FilaDeEsperaInternacaoVazia())
            {
                Console.WriteLine("Nenhum paciente!!");
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
