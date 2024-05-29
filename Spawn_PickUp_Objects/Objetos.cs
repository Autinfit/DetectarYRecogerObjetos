using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spawn_PickUp_Objects
{
    internal class Objetos
    {
        // AQUÍ VAMOS A CREAR VARIABLES A LA CLASE...

        public int posicionX; // POSICIÓN X DEL OBJETO.
        public int posicionY; // POSICIÓN Y DEL OBJETO.
        public Image imagen_objeto; // OBJETOS.
        public int altura; // ALTURA DEL OBJETO.
        public int ancho; // ANCHO DEL OBJETO.
        public string nombre; // NOMBRE DEL OBJETO.

        Random rango = new Random(); // RANGO ALEATORIO DE MOVIMIENTOS.
        int tiempoVida = 200; // TIEMPO DE EJECUCIÓN DEL PERSONAJE.
        public bool expirado = false; // NO ESTÁ EXPIRADO POR EL MOMENTO EL JUEGO.

        // CONSTRUCTOR DE LA CLASE...

        public Objetos()
        {
            imagen_objeto = Image.FromFile("Recursos/item_01.png"); // IMÁGENES DE OBJETOS IMPORTADAS MEDIANTE DIRECTORIO YA CREADO EN EL EXPLORADOR DE SOLUCIONES.
            posicionX = rango.Next(10, 700); // POSICIÓN EN X EN DONDE SE ENCUENTRA UN OBJETO DEFINIDA MEDIANTE UN RANGO ALEATORIO ENTRE AQUELLOS NÚMEROS DEL 10 AL 700 HORIZONTALMENTE.
            posicionY = rango.Next(10, 500); // POSICIÓN EN Y EN DONDE SE ENCUENTRA UN OBJETO DEFINIDA MEDIANTE UN RANGO ALEATORIO ENTRE AQUELLOS NÚMEROS DEL 10 AL 500 VERTICALMENTE.

            // CADA OBJETO MIDE 50 * 50 DE...

            altura = 50; // ALTURA MÁXIMA DE CADA OBJETO.
            ancho = 50; // ANCHO MÁXIMO DE CADA OBJETO.
        }

        // TAMBIÉN SE CONSIDERA UN TEMPORIZADOR MEDIANTE TIEMPO DE VIDA QUE LE QUEDA AL PERSONAJE...

        public void medidorDeTiempo()
        {
            tiempoVida--; // TIEMPO DE VIDA SE VA DESCONTANDO A MEDIDA QUE FALLA O SE QUEDA POR ALGÚN RATO.

            // SI SE ACABA EL TIEMPO O LLEGA A 0...

            if (tiempoVida < 1)
            {
                expirado = true; // EL JUEGO YA NO SE EJECUTARÁ MÁS Y SE ACABA LA PARTIDA.
            }
        }
    }
}
