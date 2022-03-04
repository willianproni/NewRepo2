using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjHospitalCovid.Filas;

namespace ProjHospitalCovid
{
    internal class Armazenar
    {
        public FilaNormal FilaNormal { get; set; }
        public FilaPreferencial FilaPreferencial { get; set; }
        public void RegistrarPessoa()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\5by5\\HospitalCovid\\Pacientes\\Pacientes.txt");
  
                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception " + e.Message);
            }
            finally
            {
                Console.WriteLine("Registrando Pessoa na Lista");
            }
        }
    }
}
