using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionExamenCursoNet
{
    public class TransaccionInterna : Transaccion
    {
        public string CuentaDestino { get; set; }

        public TransaccionInterna(int noTx, int valor, string cuenta) : base(noTx, valor, cuenta)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", base.ToString(), CuentaDestino);
        }
    }
}
