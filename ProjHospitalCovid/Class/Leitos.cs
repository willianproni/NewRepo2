using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid.Class
{
    internal class Leitos
    {
        public int TotalLeitos { get; set; }
        public int LeitosOcupados { get; set; }
        public int LeitosDisponiveis => TotalLeitos - LeitosOcupados;

        public Leitos()
        {
            TotalLeitos = 10;
        }

        public bool PossuiVaga()
        {
            if (LeitosDisponiveis > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
