using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid.Class
{
    internal class Sintomas
    {
        public bool FaltaAr { get; set; }
        public bool DorPeito { get; set; }
        public bool PerdaMotora { get; set; }
        public bool PercaPaladar { get; set; }
        public bool PercaOlfato { get; set; }

        public bool SintomasCovid()
        {
            if (FaltaAr) return true;
            if (DorPeito) return true;
            if (PerdaMotora) return true;
            if (PercaPaladar) return true;
            if (PercaOlfato) return true;
            else
            {
                return false;
            }
        }
    }
}
