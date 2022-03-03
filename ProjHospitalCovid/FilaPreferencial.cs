using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
