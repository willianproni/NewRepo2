using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

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

        public Paciente[] ObterTodos()
        {
            Paciente[] pacientes = new Paciente[Count()];
            int count = 0;

            if (ListaPacienteVazia()) return null;
            else
            {
                Paciente paciente = Head;
                do
                {
                    pacientes[count++] = paciente;

                    paciente = paciente.Proximo;

                } while (paciente != null);
            }

            return pacientes;
        }

        public int Count()
        {
            if (ListaPacienteVazia()) return 0;
            else
            {
                Paciente paciente = Head;
                int count = 0;
                do
                {
                    count++;
                    paciente = paciente.Proximo;

                } while (paciente != null);
                return count;
            }

        }

        public Paciente[] BuscaPeloCPFNome(string busca)
        {
            Paciente[] buscaPaciente = new Paciente[Count()];
            int countSearch = 0;

            if (ListaPacienteVazia()) return null;
            else
            {
                Paciente paciente = Head;
                do
                {
                    if (paciente.Nome.ToLower().Contains(busca.ToLower()) || paciente.Cpf.Contains(busca))
                    {
                        buscaPaciente[countSearch++] = paciente;
                    }
                    paciente = paciente.Proximo;
                } while (paciente != null);
            }
            return buscaPaciente;
        }
    }
}
