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
    }
}
