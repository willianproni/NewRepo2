using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjHospitalCovid.Class;

namespace ProjHospitalCovid.Filas
{
    internal class ListaInternados
    {
        public Paciente Head { get; set; }
        public Paciente Tail { get; set; }

        public ListaInternados()
        {
            Head = Tail = null;
        }

        public bool ListaInternadosVazia()
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

        public void InserirPacienteInternacao(Paciente paciente)
        {
            if (ListaInternadosVazia())
            {
                Head = paciente;
                Tail = paciente;
            }
            else
            {
                paciente.Anterior = Tail;
                Tail.Proximo = paciente;
                Tail = paciente;
                OrdenarLeitos();
            }
        }

        public void ExibirPacientesInternados()
        {
            if (ListaInternadosVazia())
            {
                Console.WriteLine("Nenhum Paciente internado Que bom :)");
            }
            Paciente paciente = Head;
            do
            {
                Console.WriteLine(paciente.DadosCompletos());
                paciente = paciente.Proximo;
            } while (paciente != null);
        }

        public void RemoverInternação(Paciente aux)
        {
            if (ListaInternadosVazia())
            {
                Console.WriteLine("Vazia");
            }
            else
            {
            aux = null;
            }
        }

        public void OrdenarLeitos()
        {
            for (Paciente referencia = Head; referencia != null; referencia = referencia.Proximo)
            {
                for (Paciente comparacao = referencia.Proximo; comparacao != null; comparacao = comparacao.Proximo)
                {
                    if (String.Compare(referencia.Nome, comparacao.Nome) > 0)
                    {
                        if (referencia.Anterior != null && referencia.Anterior != comparacao)
                            referencia.Anterior.Proximo = comparacao;

                        if (referencia.Anterior == null && comparacao.Proximo == null && referencia.Proximo == comparacao)
                        {
                            referencia.Proximo = comparacao.Proximo;
                        }
                        else if (referencia.Proximo != comparacao)
                        {
                            comparacao.Anterior.Proximo = comparacao.Proximo;
                            Tail = comparacao.Anterior;
                        }
                        else
                        {
                            referencia.Proximo = comparacao.Proximo;
                        }

                        comparacao.Anterior = referencia.Anterior;
                        comparacao.Proximo = referencia;

                        referencia.Anterior = comparacao;


                        if (referencia.Anterior == null)
                            Head = referencia;

                        if (comparacao.Proximo == null)
                            Tail = comparacao;

                        if (referencia.Proximo == null)
                            Tail = referencia;

                        if (comparacao.Anterior == null)
                            Head = comparacao;

                    }
                }
            }
        }
    }
}
