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
            Configuracion(); // LLAMADO DEL MÉTODO.
        }

        private void EventoPresionarTeclas(object sender, KeyEventArgs e)
        {
            // EVENTO PARA PRESIONAR CUALQUIER TECLA DEL TECLADO...

            if (e.KeyCode == Keys.Left) // SI SE PRESIONA LA TECLA IZQUIERDA...
            {
                izquierda = true; // EL JUGADOR VA HACIA LA IZQUIERDA.
            }

            if (e.KeyCode == Keys.Right) // SI SE PRESIONA LA TECLA DERECHA...
            {
                derecha = true; // EL JUGADOR VA HACIA LA DERECHA.
            }

            if (e.KeyCode == Keys.Up) // SI SE PRESIONA LA TECLA DE ARRIBA...
            {
                arriba = true; // EL JUGADOR VA HACIA ARRIBA.
            }

            if (e.KeyCode == Keys.Down) // SI SE PRESIONA LA TECLA DE ABAJO...
            {
                abajo = true; // EL JUGADOR VA HACIA ABAJO.
            }
        }

        private void EventoSoltarTeclas(object sender, KeyEventArgs e)
        {
            // EVENTO PARA SOLTAR CUALQUIER TECLA DEL TECLADO...

            if (e.KeyCode == Keys.Left) // SI SUELTA LA TECLA IZQUIERDA DEL TECLADO...
            {
                izquierda = false; // EL JUGADOR NO VA HACIA LA IZQUIERDA.
            }

            if (e.KeyCode == Keys.Right) // SI SUELTA LA TECLA DERECHA DEL TECLADO...
            {
                derecha = false; // EL JUGADOR NO VA HACIA LA DERECHA.
            }

            if (e.KeyCode == Keys.Up) // SI SUELTA LA TECLA DE ARRIBA DEL TECLADO...
            {
                arriba = false; // EL JUGADOR NO VA HACIA ARRIBA.
            }

            if (e.KeyCode == Keys.Down) // SI SUELTA LA TECLA DE ABAJO DEL TECLADO...
            {
                abajo = false; // EL JUGADOR NO VA HACIA ABAJO.
            }
        }

        private void EventoDiseñoFormulario(object sender, PaintEventArgs e)
        {
            // EVENTO PARA EDITAR EL FORMULARIO MEDIANTE COMPONENTES GRÁFICOS...

            Graphics Canvas = e.Graphics; // AGREGAREMOS UN LIENZO AL CANVAS DEL FORMULARIO.

            if (lista_objetos != null) // SI SE ENCUENTRAN LOS OBJETOS MEDIANTE UNA LISTA...
            {
                foreach (Objetos objeto in lista_objetos) // ASOCIAREMOS A CADA OBJETO DENTRO DE LA LISTA...
                {
                    // ...AGREGANDO SUS CARACTERÍSTICAS RESPECTIVAS AL FORMULARIO!

                    Canvas.DrawImage(objeto.imagen_objeto, objeto.posicionX, objeto.posicionY, objeto.ancho, objeto.altura); // DIBUJAREMOS A UN OBJETO CUALQUIERA CON SUS ATRIBUTOS PRINCIPALES...
                }
            }

            // LUEGO, DIBUJAREMOS AL JUGADOR DENTRO DEL CANVAS...

            Canvas.DrawImage(jugador, jugadorEnX, jugadorEnY, anchoJugador, alturaJugador);
        }

        private void TiempoEjecucion(object sender, EventArgs e)
        {
            // MÉTODO PARA INICIALIZAR LA EJECUCIÓN DEL PROYECTO EN GENERAL...

            // MEDIANTE MOVIMIENTOS DEL PERSONAJE, VAMOS A CONFIGURAR SUS DIRECCIONES RESPECTIVAS MEDIANTE UNA CONDICIÓN ("if")...

            if (izquierda && jugadorEnX > 0) // SI EL JUGADOR VA HACIA LA IZQUIERDA...
            {
                jugadorEnX -= velocidadJugador; // LA VELOCIDAD SE DIRIGE HACIA EL LADO CONTRARIO.
                AnimarJugador(4, 7); // LAS ANIMACIONES VAN A SER DEFINIDAS MEDIANTE SUS CANTIDADES RESPECTIVAS PARA CADA CLON DEL JUGADOR.
            }

            else if (derecha && jugadorEnX + anchoJugador < this.ClientSize.Width) // SI EL JUGADOR VA HACIA LA DERECHA...
            {
                jugadorEnX += velocidadJugador; // LA VELOCIDAD SE DIRIGE HACIA EL LADO DIRECTO.
                AnimarJugador(8, 11); // LAS ANIMACIONES VAN A SER DEFINIDAS MEDIANTE SUS CANTIDADES RESPECTIVAS PARA CADA CLON DEL JUGADOR.
            }

            else if (arriba && jugadorEnY > 0) // SI EL JUGADOR VA HACIA ARRIBA...
            {
                jugadorEnY -= velocidadJugador; // LA VELOCIDAD SE DIRIGE HACIA EL LADO CONTRARIO.
                AnimarJugador(12, 15); // LAS ANIMACIONES VAN A SER DEFINIDAS MEDIANTE SUS CANTIDADES RESPECTIVAS PARA CADA CLON DEL JUGADOR.
            }

            else if (abajo && jugadorEnY + alturaJugador < this.ClientSize.Height) // SI EL JUGADOR VA HACIA ABAJO...
            {
                jugadorEnY += velocidadJugador; // LA VELOCIDAD SE DIRIGE HACIA EL LADO DIRECTO.
                AnimarJugador(0, 3); // LAS ANIMACIONES VAN A SER DEFINIDAS MEDIANTE SUS CANTIDADES RESPECTIVAS PARA CADA CLON DEL JUGADOR.
            }

            else
            {
                AnimarJugador(0, 0);
            }

            this.Invalidate();
            cantidadMovimientos.Text = "Movimientos: " + pasos;
        }

        private void Configuracion()
        {
            this.BackgroundImage = Image.FromFile("bg.jpg"); // SE CARGA LA IMAGEN DE FONDO IMPORTADO DENTRO DEL DIRECTORIO.
            this.BackgroundImageLayout = ImageLayout.Stretch; // EL FONDO DE LA IMAGEN QUEDARÁ ENDEREZADA.
            this.DoubleBuffered = true; // TODA LA EJECUCIÓN DEL PROGRAMA VA A QUEDAR MEDIANTE UN DOBLE BÚFER.

            // CARGA LOS ARCHIVOS DEL JUGADOR MEDIANTE UNA LISTA DE MOVIMIENTOS MÁS LOS OBJETOS...

            movimientosPersonaje = Directory.GetFiles("player", "*.png").ToList();
            jugador = Image.FromFile(movimientosPersonaje[0]);
            ubicacion_objeto = Directory.GetFiles("items", "*.png").ToList();
        }

        private void AnimarJugador(int inicio, int fin)
        {
            // MÉTODO PARA ANIMAR AL JUGADOR MIENTRAS CAMINA DANDO PASOS...

            reducirFrecuenciaPatrones += 1; // MIENTRAS EL PERSONAJE CAMINA...

            if (reducirFrecuenciaPatrones == 4) // SI LA FRECUENCIA DE LOS PATRONES MEDIANTE RECURSOS SON DE 4 MIENTRAS CAMINA...
            {
                pasos++; // ENTONCES SE ASOCIA A QUE EL PERSONAJE PUEDA CAMINAR MEDIANTE CANTIDAD DE PASOS CON LOS PIES.
                reducirFrecuenciaPatrones = 0; // MIENTRAS QUE EL PERSONAJE QUEDA PARADO INICIALMENTE.
            }

            // ANÁLISIS DE ANIMACIÓN AL CAMINAR ESTE PERSONAJE MEDIANTE UN INICIO Y UN FIN...

            if (pasos > fin || pasos < inicio)
            {
                pasos = inicio; // INICIA LA CAMINATA DEL PERSONAJE MEDIANTE PATRONES DE RECURSOS DE ANIMACIÓN.
            }

            jugador = Image.FromFile(movimientosPersonaje[pasos]); // SE EXTRAE DEL DIRECTORIO ALGUNOS RECURSOS NECESARIOS DEL PERSONAJE PARA EFECTUAR LA ANIMACIÓN.
        }
    }
}