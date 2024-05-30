namespace Spawn_PickUp_Objects
{
    public partial class Form1 : Form
    {
        // CREAREMOS ALGUNAS DE SUS VARIABLES PARA ESTE PROYECTO...

        Image jugador; // PARA EL JUGADOR.
        List<string> movimientosPersonaje = new List<string>(); // MOVIMIENTOS DEL PERSONAJE MEDIANTE UNA LISTA.
        int pasos = 0; // CANTIDAD DE PASOS QUE MUEVE AQUELLO PERSONAJE.
        int reducirFrecuenciaPatrones = 0; // REDUCCIÓN DE FRECUENCIA DE PATRONES DEL PROYECTO.
        bool izquierda, derecha, arriba, abajo; // DECISIÓN DEL USUARIO HACIA DONDE MUEVE EL PERSONAJE.
        int jugadorEnX; // POSICIÓN DEL JUGADOR EN X DE MANERA HORIZONTAL.
        int jugadorEnY; // POSICIÓN DEL JUGADOR EN Y DE MANERA VERTICAL.
        int alturaJugador = 100; // ALTURA DEL JUGADOR EN EL JUEGO DE MANERA DINÁMICA AQUÍ.
        int anchoJugador = 100; // ANCHO DEL JUGADOR EN EL JUEGO DE MANERA DINÁMICA AQUÍ.
        int velocidadJugador = 10; // LA VELOCIDAD DEL JUGADOR SERÁ DE 8 KM.

        // VARIABLES POR OBJETOS...

        List<string> ubicacion_objeto = new List<string>(); // UBICACIÓN DEL OBJETO.
        List<Objetos> lista_objetos = new List<Objetos>(); // LISTA DE OBJETOS.
        int deteccionLimiteTiempo = 50; // SE VISUALIZA EL OBJETO AL MÁXIMO 50 SEGUNDOS.
        int contadorTiempo = 0; // INICIALIZA EL CONTADOR DE TIEMPO EN 0.
        Random aleatorio = new Random(); // VARIABLE ALEATORIA.
        string[] nombreObjetos = { "espada roja", "armadura mediana", "zapatos verdes", "lampara dorada", "pocima roja", "espada veloz", "instruccion manual", "espada gigante", "chaqueta abrigadora", "sombrero hechizado", "arco y flecha roja", "lanza roja", "pocima verde", "armadura pesada", "hacha maldita", "anillo dorado", "anillo purpura" };

        public Form1()
        {
            InitializeComponent();
        }
    }
}