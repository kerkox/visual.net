using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionExamenCursoNet
{
   public  class Transaccion
    {
        public int NoTx { get; private set; }
        public int Valor { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Cuenta { get; private set; }

        public Transaccion(int noTx, int valor, string cuenta)
        {
            NoTx = noTx;
            Valor = valor;
            FechaCreacion = DateTime.Now;
            Cuenta = cuenta;
        }

        public void Cancelar()
        { 
          
        }

        public void Aprobar()
        {

        }

        public void Procesar()
        {

        }

        public TimeSpan CalcularAntiguedad()
        {
           return DateTime.Now.Subtract(FechaCreacion);
        }

        public TimeSpan CalcularAntiguedad(DateTime fechaDada)
        {
            return fechaDada.Subtract(FechaCreacion);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", NoTx, Valor, FechaCreacion, Cuenta);
        }

    }
}
