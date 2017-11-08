using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo5
{
    public enum Picante
    {
        Bajo, Picante, Fuego, N911
    }


    public static class PicanteExtensiones
    {
        public static Picante ValorAnterior(this Picante picanteReferencia)
        {
            int num = (int)picanteReferencia;
            int nuevo = num - 1;
            return (Picante)nuevo;
        }

        public static string AMayusculas(this string cadena)
        {
            return cadena.ToUpper();
        }
    } 

    public abstract class Facturable
    {
        public abstract int CalcularValor();

        public int CalcularValorAFacturar()
        {
            //1. Obtener tasas de conversion.
            //2. Calcular impuestos
            //3. CalcularValorInterno
            int valor = CalcularValor();
            //4.Actualizar inventarios
            //formula de valor a facturar final
            return valor;
        }
    }

    public class Servicio : Facturable
    {
        public override int CalcularValor()
        {
            throw new NotImplementedException();
        }
    }

    public class Producto : Facturable
    {
        public override int CalcularValor()
        {
            throw new NotImplementedException();
        }
    }

    public class Facturaador
    {
        public void Facturar(IEnumerable<Facturable> servicios)
        {
            Console.WriteLine("Facturando items");
            foreach (var item in servicios)
            {
                Console.WriteLine("Calculando valor item");
                int valor = item.CalcularValorAFacturar();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Picante p = Picante.N911;
            Picante pAnterior = p.ValorAnterior();

            Console.WriteLine("Para {0} el nivel anterior es {1}", p, pAnterior);

            Console.WriteLine("a mayusculas".AMayusculas());
            Console.ReadLine();
        }
    }
}
