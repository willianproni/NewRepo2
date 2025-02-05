﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid
{
    internal class Triagem
    {
        public double Pressao { get; set; }
        public double Temperatura { get; set; }
        public int Batimentos { get; set; }
        public int Saturacao { get; set; }
        public bool PossuiComorbidade { get; set; }
        public int DiasSintomas { get; set; }
        public Sintomas Sintomas { get; set; }
        public Comorbidade Comorbidade { get; set; }

        public Triagem()
        {
            Sintomas = new Sintomas();
            Comorbidade = new Comorbidade();
        }

        public bool PacienteVaiFazerTesteCovid()
        {
            if (Sintomas.SintomasCovid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string DadosTriagem()
        {
            return $"\nPressão: {Pressao}" +
                   $"\nTempetura: {Temperatura}" +
                   $"\nBatimentos Cardíacos: {Batimentos}" +
                   $"\nSaturação: {Saturacao}" +
                   $"\nPossui Comorbidade: {PossuiComorbidade}" +
                   $"\nDias Sintomas: {DiasSintomas}";
        }
    }
}
