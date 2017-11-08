using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo3EjercicioMenu
{
    public class Menu
    {
        public IList<Bebida> Bebidas { get; set; }
        public IList<Plato> Platos { get; set; }

        public Bebida this[int index]
        {
            get { return Bebidas[index]; }
        }

        public Menu()
        {
            Bebidas = new List<Bebida>();
            Platos = new List<Plato>();
        }

        public void AgregarBebida(Bebida bebida)
        {
            Bebidas.Add(bebida);
        }

        public void AgregarPlato(Plato plato)
        {
            Platos.Add(plato);
        }
    }

    #region Bebidas

    public class Bebida : IEquatable<Bebida>
    {
        public Bebida(string nombre, int volumen)
        {
            Nombre = nombre;
            Volumen = volumen;
        }

        public string Nombre { get; set; }
        public int Volumen { get; set; }

        public bool Equals(Bebida other)
        {
            if (other == null)
            {
                return false;
            }

            return string.Equals(Nombre, other.Nombre)
                && Volumen == other.Volumen;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Nombre, Volumen);
        }
    }

    public class Gaseosa : Bebida, IEquatable<Gaseosa>
    {
        public Gaseosa(string nombre, int volumen) : base(nombre, volumen)
        {
        }

        public string Marca { get; set; }
        public string Sabor { get; set; }

        public override bool Equals(object obj)
        {
            Gaseosa gas2 = obj as Gaseosa;
            if (gas2 == null)
            {
                return false;
            }

            return string.Equals(Marca, gas2.Marca)
                && string.Equals(Sabor, gas2.Sabor)
                && string.Equals(Nombre, gas2.Nombre)
                && Volumen == gas2.Volumen;
        }

        public bool Equals(Gaseosa gas2)
        {
            if (gas2 == null)
            {
                return false;
            }

            return string.Equals(Marca, gas2.Marca)
                && string.Equals(Sabor, gas2.Sabor)
                && base.Equals(gas2);
        }
    }

    public class JugoFruta : Bebida
    {
        public JugoFruta(string nombre, int volumen) : base(nombre, volumen)
        {
            Frutas = new List<string>();
        }

        public IList<string> Frutas { get; set; }
    }

    #endregion

    #region Platos

    public enum Picante
    {
        Bajo, Picante, Fuego, N911
    }

    public class Plato
    {
        public string Nombre { get; set; }
        public Picante NivelPicante { get; set; }
    }

    public class Gourmet : Plato
    {

    }

    public class Asado : Plato
    {

    }

    public class Vegetariano : Plato
    {

    }

    #endregion

    #region Pagos

    public enum TipoTarjeta
    {
        Visa, Mastercard, Diners, AmericanExpress
    }

    public struct PagoEfectivo
    {
        public int Valor { get; set; }
        public DateTime FechaPago { get; set; }
    }

    public struct PagoTarjetaCredito
    {
        public int Valor { get; set; }
        public DateTime FechaPago { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }
    }

    public struct PagoNomina
    {
        public int Valor { get; set; }
        public DateTime FechaPago { get; set; }
    }

#endregion


    class Program
    {
        static void Suma<T>(T a, T b) where T : struct
        {
            Console.WriteLine("{0} {1}", a, b); 
        }

        static IEnumerator<Bebida> RegistrarBebidas(IEnumerable<Bebida> arBebidas)
        {
            var enBebidas = arBebidas.GetEnumerator();
            while (enBebidas.MoveNext())
            {
                Console.WriteLine(enBebidas.Current);
            }

            foreach (var bebida in arBebidas)
            {
                Console.WriteLine(enBebidas.Current);
                yield return bebida;
            }
        }


        static void Main(string[] args)
        {
            Suma<int>(6, 7);

            Gaseosa bebida1 = new Gaseosa("Manzana Postobon", 650);
            Gaseosa bebida2 = new Gaseosa("Manzana Postobon", 650);
            Console.WriteLine("bebida1 equals bebida 1 {0}", bebida1.Equals(bebida1));
            Console.WriteLine("bebida2 equals bebida 2 {0}", bebida2.Equals(bebida2));
            Console.WriteLine("bebida1 equals bebida 2 {0}", bebida1.Equals(bebida2));
            Console.WriteLine("bebida2 equals bebida 1 {0}", bebida2.Equals(bebida1));

            JugoFruta jf = new JugoFruta("Verde", 500);
            

            Menu menuCafeteriaEsquina = new Menu();
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Manzana Postobon", 650));
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Colombiana Postobon", 700));
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Cocacola", 500));
            
            Bebida b1 = menuCafeteriaEsquina[1];

            /*
            Menu[] menusOctubre = new Menu[2];
            Bebida bPrimera = menusOctubre[0][0];
            */

            var bebidas = (from Bebida b in menuCafeteriaEsquina.Bebidas
                          orderby b.Volumen ascending
                          select b).ToList();

            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Pepsi", 500));

            foreach (var bebida in bebidas)
            {
                Console.WriteLine(bebida);
            }

            Console.WriteLine("------------------------");
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Popular", 500));

            foreach (var bebida in bebidas)
            {
                Console.WriteLine(bebida);
            }


            Console.ReadLine();
        }
    }
}
