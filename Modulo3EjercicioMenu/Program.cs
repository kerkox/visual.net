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

        public Plato this[int index]
        {
            get { return Platos[index]; }
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

    public class Bebida
    {
        public Bebida(string nombre, int volumen)
        {
            Nombre = nombre;
            Volumen = volumen;
        }

        public string Nombre { get; set; }
        public int Volumen { get; set; }
    }

    public class Gaseosa : Bebida
    {
        public Gaseosa(string nombre, int volumen) : base(nombre, volumen)
        {
        }

        public string Marca { get; set; }
        public string Sabor { get; set; }
    }

    public class JugoFruta : Bebida
    {
        public JugoFruta(string nombre, int volumen) : base(nombre, volumen)
        {
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
        static void Main(string[] args)
        {
            Menu menuCafeteriaEsquina = new Menu();
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Manzana Postobon", 350));
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Colombiana Postobon", 350));
            menuCafeteriaEsquina.AgregarBebida(new Gaseosa("Cocacola", 350));
        }
    }
}
