namespace Spawn_PickUp_Objects
{
    public partial class Form1 : Form
    {
        // CREAREMOS ALGUNAS DE SUS VARIABLES PARA ESTE PROYECTO...

        Image jugador; // PARA EL JUGADOR.
        List<string> movimientosPersonaje = new List<string>(); // MOVIMIENTOS DEL PERSONAJE MEDIANTE UNA LISTA.
        int pasos = 0; // CANTIDAD DE PASOS QUE MUEVE AQUELLO PERSONAJE.
        int reducirFrecuenciaPatrones = 0; // REDUCCI�N DE FRECUENCIA DE PATRONES DEL PROYECTO.
        bool izquierda, derecha, arriba, abajo; // DECISI�N DEL USUARIO HACIA DONDE MUEVE EL PERSONAJE.
        int jugadorEnX; // POSICI�N DEL JUGADOR EN X DE MANERA HORIZONTAL.
        int jugadorEnY; // POSICI�N DEL JUGADOR EN Y DE MANERA VERTICAL.
        int alturaJugador = 100; // ALTURA DEL JUGADOR EN EL JUEGO DE MANERA DIN�MICA AQU�.
        int anchoJugador = 100; // ANCHO DEL JUGADOR EN EL JUEGO DE MANERA DIN�MICA AQU�.
        int velocidadJugador = 10; // LA VELOCIDAD DEL JUGADOR SER� DE 8 KM.

        // VARIABLES POR OBJETOS...

        List<string> ubicacion_objeto = new List<string>(); // UBICACI�N DEL OBJETO.
        List<Objetos> lista_objetos = new List<Objetos>(); // LISTA DE OBJETOS.
        int deteccionLimiteTiempo = 50; // SE VISUALIZA EL OBJETO AL M�XIMO 50 SEGUNDOS.
        int contadorTiempo = 0; // INICIALIZA EL CONTADOR DE TIEMPO EN 0.
        Random aleatorio = new Random(); // VARIABLE ALEATORIA.
        string[] nombreObjetos = { "espada roja", "armadura mediana", "zapatos verdes", "lampara dorada", "pocima roja", "espada veloz", "instruccion manual", "espada gigante", "chaqueta abrigadora", "sombrero hechizado", "arco y flecha roja", "lanza roja", "pocima verde", "armadura pesada", "hacha maldita", "anillo dorado", "anillo purpura" };

        public Form1()
        {
            InitializeComponent();
            Configuracion(); // LLAMADO DEL M�TODO.
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

        private void EventoDise�oFormulario(object sender, PaintEventArgs e)
        {
            // EVENTO PARA EDITAR EL FORMULARIO MEDIANTE COMPONENTES GR�FICOS...

            Graphics Canvas = e.Graphics; // AGREGAREMOS UN LIENZO AL CANVAS DEL FORMULARIO.

            if (lista_objetos != null) // SI SE ENCUENTRAN LOS OBJETOS MEDIANTE UNA LISTA...
            {
                foreach (Objetos objeto in lista_objetos) // ASOCIAREMOS A CADA OBJETO DENTRO DE LA LISTA...
                {
                    // ...AGREGANDO SUS CARACTER�STICAS RESPECTIVAS AL FORMULARIO!

                    Canvas.DrawImage(objeto.imagen_objeto, objeto.posicionX, objeto.posicionY, objeto.ancho, objeto.altura); // DIBUJAREMOS A UN OBJETO CUALQUIERA CON SUS ATRIBUTOS PRINCIPALES...
                }
            }

            // LUEGO, DIBUJAREMOS AL JUGADOR DENTRO DEL CANVAS...

            Canvas.DrawImage(jugador, jugadorEnX, jugadorEnY, anchoJugador, alturaJugador);
        }

        private void Configuracion()
        {
            this.BackgroundImage = Image.FromFile("bg.jpg"); // SE CARGA LA IMAGEN DE FONDO IMPORTADO DENTRO DEL DIRECTORIO.
            this.BackgroundImageLayout = ImageLayout.Stretch; // EL FONDO DE LA IMAGEN QUEDAR� ENDEREZADA.
            this.DoubleBuffered = true; // TODA LA EJECUCI�N DEL PROGRAMA VA A QUEDAR MEDIANTE UN DOBLE B�FER.

            // CARGA LOS ARCHIVOS DEL JUGADOR MEDIANTE UNA LISTA DE MOVIMIENTOS M�S LOS OBJETOS...

            movimientosPersonaje = Directory.GetFiles("player", "*.png").ToList();
            jugador = Image.FromFile(movimientosPersonaje[0]);
            // ubicacion_objeto = Directory.GetFiles("player", "*.png").ToList();
        }

        private void AnimarJugador(int inicio, int fin)
        {
            // M�TODO PARA ANIMAR AL JUGADOR MIENTRAS CAMINA DANDO PASOS...

            reducirFrecuenciaPatrones += 1; // MIENTRAS EL PERSONAJE CAMINA...

            if (reducirFrecuenciaPatrones == 4) // SI LA FRECUENCIA DE LOS PATRONES MEDIANTE RECURSOS SON DE 4 MIENTRAS CAMINA...
            {
                pasos++; // ENTONCES SE ASOCIA A QUE EL PERSONAJE PUEDA CAMINAR MEDIANTE CANTIDAD DE PASOS CON LOS PIES.
                reducirFrecuenciaPatrones = 0; // MIENTRAS QUE EL PERSONAJE QUEDA PARADO INICIALMENTE.
            }

            // AN�LISIS DE ANIMACI�N AL CAMINAR ESTE PERSONAJE MEDIANTE UN INICIO Y UN FIN...

            if (pasos > fin || pasos < inicio)
            {
                pasos = inicio; // INICIA LA CAMINATA DEL PERSONAJE MEDIANTE PATRONES DE RECURSOS DE ANIMACI�N.
            }

            jugador = Image.FromFile(movimientosPersonaje[pasos]); // SE EXTRAE DEL DIRECTORIO ALGUNOS RECURSOS NECESARIOS DEL PERSONAJE PARA EFECTUAR LA ANIMACI�N.
        }

        private void CrearObjetos()
        {
            // NUEVO M�TODO PARA CREAR OBJETOS QUE APAREZCAN DIN�MICAMENTE A LA INTERFAZ...

            int i = aleatorio.Next(0, ubicacion_objeto.Count); // CANTIDAD DE OBJETOS AL AZAR.

            Objetos nuevoObjeto = new Objetos(); // SE CREA UN NUEVO OBJETO.
            nuevoObjeto.imagen_objeto = Image.FromFile(ubicacion_objeto[i]); // OBJETOS MEDIANTE SU PROPIA UBICACI�N.
            nuevoObjeto.nombre = nombreObjetos[i]; // NOMBRE DE CADA OBJETO EN PARTICULAR.
            contadorTiempo = deteccionLimiteTiempo; // VA CONTABILIZANDO EL TIEMPO A MEDIDA DE QUE VA EN CUENTA REGRESIVA...
            lista_objetos.Add(nuevoObjeto); // A�ADE UN NUEVO OBJETO A LA LISTA DE OBJETOS EXISTENTES DENTRO DEL EXPLORADOR DE SOLUCIONES.
        }

        private void ChequearColisiones()
        {
            // NUEVO M�TODO PARA EFECTUAR CHEQUEO DE COLISIONES...

            // POR CADA OBJETO DENTRO DE UNA LISTA DE OBJETOS...

            foreach (Objetos item in lista_objetos)
            {
                item.medidorDeTiempo(); // LLAMADO DEL M�TODO A INSTANCIAR OBJETOS DENTRO DE ESTA CLASE.

                if (item.expirado) // SI NO EST�N LOS OBJETOS APENAS SE ACABA EL TIEMPO...
                {
                    item.imagen_objeto = null; // NO HAY NING�N OBJETO.
                    lista_objetos.Remove(item); // ELIMINA LOS OBJETOS DE LA LISTA.
                }

                bool colisiones = DetectarColisiones(jugadorEnX, jugadorEnY, jugador.Width, jugador.Height, item.posicionX, item.posicionY, item.ancho, item.altura);

                if (colisiones) // SI SE DETECTAN ALGUNA COLISI�N ENTRE EL PERSONAJE Y UN OBJETO CUALQUIERA...
                {
                    cantidadObjetos.Text = "Objetos coleccionados: " + item.nombre;
                    item.imagen_objeto = null; // NO HAY OBJETOS CUANDO EL PERSONAJE LO RECOGI�.
                    lista_objetos.Remove(item); // ELIMINA EL OBJETO DENTRO DE UNA LISTA DE OBJETOS.
                }
            }
        }

        private bool DetectarColisiones(int objetoX1, int objetoY1, int alturaObjeto1, int anchoObjeto1, int objetoX2, int objetoY2, int alturaObjeto2, int anchoObjeto2)
        {
            // NUEVO M�TODO PARA DETECTAR COLISIONES CON OBJETOS POR PARTE DEL PERSONAJE...

            if (objetoX1 + alturaObjeto1 <= objetoX2 || objetoX1 >= objetoX2 + anchoObjeto2 || objetoY1 + alturaObjeto1 <= objetoY2 || objetoY1 >= objetoY2 + alturaObjeto2) // SI SE POSICIONAN ESTOS OBJETOS PARA EFECTUAR COLISIONES...
            {
                return false; // NO SE DETECTA NINGUNA COLISI�N.
            }

            else
            {
                return true; // EN CASO CONTRARIO, SE DETECTAN COLISIONES.
            }
        }

        private void TiempoEjecucion(object sender, EventArgs e)
        {
            // M�TODO PARA INICIALIZAR LA EJECUCI�N DEL PROYECTO EN GENERAL...

            // MEDIANTE MOVIMIENTOS DEL PERSONAJE, VAMOS A CONFIGURAR SUS DIRECCIONES RESPECTIVAS MEDIANTE UNA CONDICI�N ("if")...

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
    }
}