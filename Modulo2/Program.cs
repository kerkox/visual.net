using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo2
{
    public class Transferencia
    {
        public int NoTx { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", NoTx);
        }
    }

    class Program
    {
        public static void CambiarTx(Transferencia tx)
        {
            tx.NoTx = 20;
        }

        public static void CambiarTxV2(Transferencia tx)
        {
            tx = new Transferencia();
            tx.NoTx = 30;
        }

        public static void CambiarTxV3(ref Transferencia tx)
        {
            tx = new Transferencia();
            tx.NoTx = 40;
        }

        public static void CambiarTxV4(out Transferencia tx)
        {
            tx = new Transferencia();
            tx.NoTx = 50;
        }

        static void Main(string[] args)
        {
            Transferencia transferencia = new Transferencia();
            transferencia.NoTx = 1;
            CambiarTx(transferencia);

            Transferencia transferencia2 = new Transferencia();
            transferencia2.NoTx = 1;
            CambiarTxV2(transferencia2);

            Transferencia transferencia3 = new Transferencia();
            transferencia3.NoTx = 1;
            CambiarTxV3(ref transferencia3);

            Transferencia transferencia4;
            CambiarTxV4(out transferencia4);

            int resultado;
            int.TryParse("1234", out resultado);

            Console.WriteLine(transferencia);
            Console.WriteLine(transferencia2);
            Console.WriteLine(transferencia3);
            Console.WriteLine(transferencia4);

            Console.ReadLine();
        }
    }
}
