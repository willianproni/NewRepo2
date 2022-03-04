using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCovid
{
    internal class Comorbidade
    {
        public bool Diabetes { get; set; }
        public bool Hipertenso { get; set; }
        public bool Cancer { get; set; }
        public bool DoencasCardiovasculares { get; set; }
        public bool DoencasPulmonares { get; set; }
        public bool Neurologicos { get; set; }

        public Comorbidade()
        {

        }

        public bool ComorbidadesPerigosasCovid()
        {
            if (Diabetes) return true;
            if (Hipertenso) return true;
            if (Cancer) return true;
            if (DoencasCardiovasculares) return true;
            if (DoencasPulmonares) return true;
            if (Neurologicos) return true;
            else
            {
                return false;
            }
        }
    }
}
