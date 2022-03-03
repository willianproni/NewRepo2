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

        public void InserirPacienteFilaNormal(Paciente novopreferencial)
        {
            if (FilaNormalVazia())
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
