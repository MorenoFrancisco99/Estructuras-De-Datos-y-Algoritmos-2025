using ConsoleApp1.DATs.Implementation;
using ConsoleApp1.Ejs;
using ConsoleApp1.Practco_2;
using System.Reflection;

namespace ConsoleApp1
{
    //al que escribio esta clase
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.BufferHeight = 5000;

            Menu menu = new Menu();
            var app = new AppContext();
            const int CAPACIDAD = 5;
            string option;

            while (true) //Bucle infinito hasta que el usuario decida salir. Se sale por otro lado
            {


                option = menu.Show();

                // option viene en el formato "Categoria/Opcion", por ejemplo: "Testear Estructuras/Lista Enlazada"
                string[] opciones = option.Split('/');
                Console.Clear();
                switch (opciones[0])
                {
                    //Todos los testeos de las estructuras van en este case.
                    //La mayoria son testeos puros aca pero a otros se les hizo una funcion especifica pra testear. No es consistente pero no quiero cambiarlo todo
                    case "Testear Estructuras":
                        switch (opciones[1])
                        {
                            case "Lista Enlazada":

                                ListaEnlazada listaE = new ListaEnlazada();

                                Console.WriteLine("=== PRUEBAS LISTA ENLAZADA ===\n");

                                // --- Prueba 1: Insertar al final ---
                                Console.WriteLine("Insertando elementos al final:");
                                listaE.Insertar(10);
                                listaE.Insertar(20);
                                listaE.Insertar(30);
                                listaE.Insertar(40);
                                listaE.Mostrar();

                                // --- Prueba 2: Insertar en posiciones específicas ---
                                Console.WriteLine("\nInsertando en posiciones específicas:");
                                listaE.InsertarEnPosicion(5, 0);   // al inicio
                                listaE.InsertarEnPosicion(25, 3);  // en el medio
                                listaE.InsertarEnPosicion(50, 6);  // al final
                                listaE.Mostrar();

                                // --- Prueba 3: Buscar elementos ---
                                Console.WriteLine("\nPrueba de búsqueda:");
                                int pos1 = listaE.Buscar(25);
                                Console.WriteLine($"Buscar(25) -> posición {pos1}");
                                int pos2 = listaE.Buscar(100);
                                Console.WriteLine($"Buscar(100) -> posición {pos2} (esperado -1)");
                                listaE.Mostrar();

                                // --- Prueba 4: Suprimir elementos ---
                                Console.WriteLine("\nPrueba de supresión:");
                                Console.WriteLine("Suprimir posición 0 (inicio): " + listaE.Suprimir(0));
                                listaE.Mostrar();

                                Console.WriteLine("Suprimir posición 2 (medio): " + listaE.Suprimir(2));
                                listaE.Mostrar();

                                Console.WriteLine("Suprimir última posición: " + listaE.Suprimir(listaE.Buscar(50)));
                                listaE.Mostrar();

                                // --- Prueba 5: Casos inválidos ---
                                Console.WriteLine("\nCasos inválidos:");
                                listaE.Suprimir(-1);
                                listaE.Suprimir(99);
                                listaE.InsertarEnPosicion(99, -5);
                                listaE.InsertarEnPosicion(99, 999);
                                listaE.Mostrar();

                                // --- Prueba 6: Vaciar completamente la lista ---
                                Console.WriteLine("\nVaciando la lista:");
                                while (!listaE.IsEmpty())
                                {
                                    listaE.Suprimir(0);
                                    listaE.Mostrar();
                                }

                                Console.WriteLine("Prueba de lista vacía:");
                                listaE.Mostrar();
                                listaE.Buscar(10);

                                break;


                            case "Lista Secuencial":
                                const int TAMANO_LISTA = 5;
                                ListaSecuencial listaSeqTest = new ListaSecuencial(TAMANO_LISTA);
                                Console.WriteLine("\n" + new string('=', 50));
                                Console.WriteLine($"--- Test Completo de Lista Secuencial (Tamaño: {TAMANO_LISTA}) ---");
                                Console.WriteLine(new string('=', 50));

                                // 1. Inicialización y Llenado Parcial
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n## 1. Inicialización y Preparación");

                                // Insertamos varios elementos para tener una lista heterogénea
                                listaSeqTest.InsertarPorPosicion(10, 0); // [10]
                                listaSeqTest.InsertarPorPosicion(5, 0);  // [5, 10]
                                listaSeqTest.InsertarPorPosicion(20, 2); // [5, 10, 20]
                                listaSeqTest.InsertarPorPosicion(10, 1); // [5, 10, 10, 20] <-- Importante para Buscar()

                                Console.Write("Lista de prueba: ");
                                listaSeqTest.Recorrer();
                                // Estado: [5, 10, 10, 20]. cant = 4.

                                // 2. Test de la función Buscar()
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 2. Test de Búsqueda (Buscar())");

                                // A. Elemento en el primer índice (0)
                                int index5 = listaSeqTest.Buscar(5);
                                Console.WriteLine($"Buscar 5: Índice {index5} (Esperado: 0)");

                                // B. Elemento repetido (debe devolver el primer índice encontrado)
                                int index10 = listaSeqTest.Buscar(10);
                                Console.WriteLine($"Buscar 10: Índice {index10} (Esperado: 1)");

                                // C. Elemento al final
                                int index20 = listaSeqTest.Buscar(20);
                                Console.WriteLine($"Buscar 20: Índice {index20} (Esperado: 3)");

                                // D. Elemento NO encontrado
                                int index99 = listaSeqTest.Buscar(99);
                                Console.WriteLine($"Buscar 99: Índice {index99} (Esperado: -1)");


                                // 3. Test de la función Recuperar()
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 3. Test de Recuperación (Recuperar())");

                                // A. Recuperar el primer elemento (índice 0)
                                int val0 = listaSeqTest.Recuperar(0);
                                Console.WriteLine($"Recuperar en índice 0: Valor {val0} (Esperado: 5)");

                                // B. Recuperar un elemento del medio (índice 2)
                                int val2 = listaSeqTest.Recuperar(2);
                                Console.WriteLine($"Recuperar en índice 2: Valor {val2} (Esperado: 10)");

                                // C. Recuperar el último elemento (índice 3)
                                int val3 = listaSeqTest.Recuperar(3);
                                Console.WriteLine($"Recuperar en índice 3: Valor {val3} (Esperado: 20)");

                                // D. Caso de borde: Posición negativa
                                Console.Write("Recuperar en índice -1: ");
                                listaSeqTest.Recuperar(-1); // Esperado: mensaje de error y -999

                                // E. Caso de borde: Posición fuera de límites (cant = 4, índice válido máximo = 3)
                                Console.Write("Recuperar en índice 4: ");
                                listaSeqTest.Recuperar(4); // Esperado: mensaje de error y -999

                                // 4. Test Combinado: Inserción, Búsqueda, Recuperación
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 4. Test Combinado: Cambios en la lista");

                                // Suprimir el primer 10 (índice 1)
                                int suprimido = listaSeqTest.Suprimir(1); // [5, 10, 20]
                                Console.WriteLine($"Suprimido en pos 1: {suprimido} (Esperado 10)");
                                Console.Write("Nuevo estado: ");
                                listaSeqTest.Recorrer();
                                // Estado: [5, 10, 20]. cant = 3.

                                // Buscar el 10 de nuevo (ahora está en índice 1)
                                int newIndex10 = listaSeqTest.Buscar(10);
                                Console.WriteLine($"Buscar 10 después de suprimir: Índice {newIndex10} (Esperado: 1)");

                                // Recuperar en el último índice (2)
                                int newVal2 = listaSeqTest.Recuperar(2);
                                Console.WriteLine($"Recuperar en índice 2: Valor {newVal2} (Esperado: 20)");

                                Console.WriteLine("\nFin de las pruebas de Búsqueda y Recuperación.");
                                break;

                            case "Pila Encadenada":

                                PilaEnlazada<int> pilaEnl = new PilaEnlazada<int>();
                                Console.WriteLine("--- Test de Robustez de Pila Enlazada ---");

                                // 1. Test de Pila Vacía Inicial
                                Console.WriteLine("\n## 1. Pila Vacia Inicial");
                                Console.Write("Estado inicial: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine($"\n¿Está vacía? {pilaEnl.IsEmpty()} (Esperado: True)"); // Se usa pilaEnl
                                Console.Write("Intento de suprimir de pila vacía: ");
                                int suprimidoVacio = pilaEnl.Suprimir(); // Se usa pilaEnl
                                Console.WriteLine($"(Valor devuelto: {suprimidoVacio}, Esperado: -1 y mensaje 'Pila Vacia')");

                                // 2. Test de Inserción (PUSH)
                                Console.WriteLine("\n" + new string('-', 20));
                                Console.WriteLine("## 2. Inserciones (PUSH)");
                                pilaEnl.Insertar(10); // Se usa pilaEnl
                                Console.Write("Insertar 10: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine();

                                pilaEnl.Insertar(20); // Se usa pilaEnl
                                Console.Write("Insertar 20: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine();

                                pilaEnl.Insertar(30); // Se usa pilaEnl
                                Console.Write("Insertar 30: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine($"\n¿Está vacía? {pilaEnl.IsEmpty()} (Esperado: False)"); // Se usa pilaEnl

                                // 3. Test de Supresión (POP)
                                Console.WriteLine("\n" + new string('-', 20));
                                Console.WriteLine("## 3. Supresiones (POP)");

                                int suprimido1 = pilaEnl.Suprimir(); // Se usa pilaEnl
                                Console.WriteLine($"Suprimido 1: {suprimido1} (Esperado: 30)");
                                Console.Write("Estado de la pila: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine();

                                int suprimido2 = pilaEnl.Suprimir(); // Se usa pilaEnl
                                Console.WriteLine($"Suprimido 2: {suprimido2} (Esperado: 20)");
                                Console.Write("Estado de la pila: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine();

                                // 4. Test de Pila con un solo elemento
                                Console.WriteLine("\n" + new string('-', 20));
                                Console.WriteLine("## 4. Pila con un solo elemento y Vaciado Total");
                                int suprimido3 = pilaEnl.Suprimir(); // Se usa pilaEnl
                                Console.WriteLine($"Suprimido 3: {suprimido3} (Esperado: 10)");
                                Console.Write("Estado de la pila: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine();
                                Console.WriteLine($"¿Está vacía? {pilaEnl.IsEmpty()} (Esperado: True)"); // Se usa pilaEnl

                                // 5. Test de Comportamiento LIFO (Last-In, First-Out)
                                Console.WriteLine("\n" + new string('-', 20));
                                Console.WriteLine("## 5. Comportamiento LIFO (Recarga)");
                                pilaEnl.Insertar(5); // Se usa pilaEnl
                                pilaEnl.Insertar(15); // Se usa pilaEnl
                                pilaEnl.Insertar(25); // Se usa pilaEnl
                                Console.Write("Pila cargada: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine("\nVerificando el orden LIFO:");

                                // El último insertado (25) debe ser el primero en salir.
                                Console.WriteLine($"POP 1 (esperado 25): {pilaEnl.Suprimir()}"); // Se usa pilaEnl
                                Console.WriteLine($"POP 2 (esperado 15): {pilaEnl.Suprimir()}"); // Se usa pilaEnl
                                Console.WriteLine($"POP 3 (esperado 5): {pilaEnl.Suprimir()}"); // Se usa pilaEnl

                                Console.Write("Estado final de la pila: ");
                                pilaEnl.Mostrar(); // Se usa pilaEnl
                                Console.WriteLine($"\n¿Está vacía? {pilaEnl.IsEmpty()} (Esperado: True)"); // Se usa pilaEnl

                                // 6. Test de Error (Suprimir en pila vacía)
                                Console.WriteLine("\n" + new string('-', 20));
                                Console.WriteLine("## 6. Caso de Borde: Suprimir en Pila Vacía");
                                Console.Write("Intento de suprimir de pila vacía (de nuevo): ");
                                pilaEnl.Suprimir(); // Se usa pilaEnl
                                Console.Write("Intento de suprimir de pila vacía (tercero): ");
                                pilaEnl.Suprimir(); // Se usa pilaEnl

                                break;
                          
                            
                            
                            case "lista enlazada ordenada":

                                break;                            
                          
                            
                            
                            case "Pila Secuencial":
                                Console.WriteLine("--- INICIO DE PRUEBAS DE ROBUSTEZ DE PILA SECUENCIAL ---");

                                // 1. Inicializar la pila con capacidad reducida para forzar límites
                               
                                PilaSecuencial pila = new PilaSecuencial(CAPACIDAD);

                                Console.WriteLine($"\n[INFO] Pila inicializada con capacidad: {CAPACIDAD}.");
                                Console.Write("Estado inicial: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                // =========================================================================
                                // 1. Pruebas de Inserción (Stack Push)
                                // =========================================================================
                                Console.WriteLine("\n--- 1. PRUEBAS DE INSERCIÓN ---");

                                // Caso 1: Inserciones normales (4 elementos)
                                pila.Insertar(10);
                                pila.Insertar(20);
                                pila.Insertar(30);
                                pila.Insertar(40);
                                Console.Write($"[TEST 1] Insertar 10, 20, 30, 40. Esperado: [40 | 30 | 20 | 10]: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                // Caso 2: Poner la pila al límite
                                pila.Insertar(50);
                                Console.Write($"[TEST 2] Insertar 50 (Pila Llena). Esperado: [50 | 40 | 30 | 20 | 10]: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                // Caso 3: Desbordamiento (Stack Overflow)
                                int resultado_error = pila.Insertar(60);
                                Console.Write($"[TEST 3] Insertar 60. Esperado: -1 (Desbordamiento). Resultado: {resultado_error}. Estado: ");
                                pila.Mostrar();
                                Console.WriteLine();


                                // =========================================================================
                                // 2. Pruebas de Eliminación (Stack Pop)
                                // =========================================================================
                                Console.WriteLine("\n--- 2. PRUEBAS DE ELIMINACIÓN ---");
                                // Estado actual: [50 | 40 | 30 | 20 | 10]

                                // Caso 4: Eliminación normal (el tope)
                                int valor_eli = pila.Suprimir();
                                Console.Write($"[TEST 4] Suprimir(). Valor Retornado: {valor_eli}. Esperado: [40 | 30 | 20 | 10]: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                // Caso 5: Eliminación de todos los elementos hasta el vacío
                                pila.Suprimir(); // 40
                                pila.Suprimir(); // 30
                                pila.Suprimir(); // 20
                                valor_eli = pila.Suprimir(); // 10
                                Console.Write($"[TEST 5] Suprimir 4 veces (Vacía). Valor Retornado (último): {valor_eli}. Estado: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                // Caso 6: Subdesbordamiento (Stack Underflow)
                                valor_eli = pila.Suprimir();
                                Console.Write($"[TEST 6] Suprimir(). Esperado: -1 (Subdesbordamiento). Resultado: {valor_eli}. Estado: ");
                                pila.Mostrar();
                                Console.WriteLine();


                                // =========================================================================
                                // 3. Pruebas de Robustez (Ciclo Completo)
                                // =========================================================================
                                Console.WriteLine("\n--- 3. PRUEBAS DE ROBUSTEZ (Ciclo) ---");

                                // Caso 7: Insertar de nuevo en pila vacía y eliminar
                                pila.Insertar(100);
                                pila.Insertar(200);
                                Console.Write($"[TEST 7.1] Insertar 100, 200. Esperado: [200 | 100]: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                pila.Suprimir(); // 200
                                pila.Suprimir(); // 100
                                Console.Write($"[TEST 7.2] Suprimir 2 veces. Estado: ");
                                pila.Mostrar();
                                Console.WriteLine();

                                Console.WriteLine("\n--- FIN DE PRUEBAS ---");

                                break;



                            case "Cola Secuencial":
                                const int TAMANO_COLA = 5;
                                // Creamos una instancia de la cola para pruebas
                                ColaSecuencial<int> cola = new ColaSecuencial<int>(TAMANO_COLA);
                                Console.WriteLine($"--- Test de Robustez de Cola Circular Secuencial (Tamaño: {TAMANO_COLA}) ---");

                                // 1. Test de Cola Vacía Inicial
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n## 1. Cola Vacía Inicial");
                                Console.WriteLine($"¿Está vacía? {cola.IsEmpty()} (Esperado: True)");
                                Console.WriteLine($"¿Está llena? {cola.IsFull()} (Esperado: False)");

                                Console.Write("Intento de suprimir de cola vacía: ");
                                int suprimidoVacioA = cola.Suprimir();
                                Console.WriteLine($"(Valor devuelto: {suprimidoVacioA}, Esperado: 0 y mensaje 'Cola Vacia')");
                                Console.Write("Recorrido de cola vacía: ");
                                cola.Recorrer();
                                Console.WriteLine("(Esperado: Ningún output)");

                                // 2. Test de Inserción hasta llenado (Enqueue)
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 2. Inserciones hasta Llenado (FIFO)");

                                Console.WriteLine("Insertando: 10, 20, 30, 40, 50...");
                                cola.Insertar(10); // primero=0, ultimo=1, cant=1
                                cola.Insertar(20); // primero=0, ultimo=2, cant=2
                                cola.Insertar(30); // primero=0, ultimo=3, cant=3
                                cola.Insertar(40); // primero=0, ultimo=4, cant=4
                                cola.Insertar(50); // primero=0, ultimo=0, cant=5 (LLena)

                                Console.WriteLine($"¿Está llena? {cola.IsFull()} (Esperado: True)");
                                Console.WriteLine($"¿Está vacía? {cola.IsEmpty()} (Esperado: False)");

                                Console.WriteLine("Recorrido de cola llena (Esperado: 10, 20, 30, 40, 50):");
                                cola.Recorrer();

                                // 3. Test de Cola Llena y Comportamiento de Error
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 3. Caso de Borde: Cola Llena");
                                Console.Write("Intento de insertar 60 en cola llena: ");
                                int insertadoLleno = cola.Insertar(60);
                                Console.WriteLine($"(Valor devuelto: {insertadoLleno}, Esperado: -1 y mensaje 'Cola Llena')");

                                Console.WriteLine("Recorrido después de intento fallido (debe seguir igual):");
                                cola.Recorrer();

                                // 4. Test de Supresión (Dequeue) y Comportamiento Circular
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 4. Supresiones y Circularidad");

                                // Suprime 10 (FIFO)
                                int sup1 = cola.Suprimir(); // primero=1, ultimo=0, cant=4
                                Console.WriteLine($"Suprimido 1 (Esperado 10): {sup1}");

                                // Suprime 20 (FIFO)
                                int sup2 = cola.Suprimir(); // primero=2, ultimo=0, cant=3
                                Console.WriteLine($"Suprimido 2 (Esperado 20): {sup2}");

                                Console.WriteLine("Estado de la cola (Esperado: 30, 40, 50):");
                                cola.Recorrer();

                                // 5. Test de Circularidad con Inserción
                                // Ahora hay espacio, el próximo elemento se insertará al principio (índice 0).
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 5. Circularidad: Reutilización de Espacios");

                                Console.WriteLine("Insertando 70 y 80 (usarán los espacios 0 y 1)");
                                cola.Insertar(70); // primero=2, ultimo=1, cant=4 (70 en arr[0])
                                cola.Insertar(80); // primero=2, ultimo=2, cant=5 (80 en arr[1]) -> LLENA DE NUEVO

                                Console.WriteLine($"¿Está llena? {cola.IsFull()} (Esperado: True)");
                                Console.WriteLine("Estado de la cola (Esperado: 30, 40, 50, 70, 80):");
                                cola.Recorrer();
                                // Nota: El recorrido debe empezar en 'primero' (30) e ir a través del índice del array hasta 'ultimo - 1' (80).

                                // 6. Test de Vaciado total y reinicio de circularidad
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 6. Vaciado Total y Reinicio");

                                Console.WriteLine($"Suprimido 3 (Esperado 30): {cola.Suprimir()}"); // primero=3, ultimo=2, cant=4
                                Console.WriteLine($"Suprimido 4 (Esperado 40): {cola.Suprimir()}"); // primero=4, ultimo=2, cant=3
                                Console.WriteLine($"Suprimido 5 (Esperado 50): {cola.Suprimir()}"); // primero=0, ultimo=2, cant=2 (Salto a índice 0)
                                Console.WriteLine($"Suprimido 6 (Esperado 70): {cola.Suprimir()}"); // primero=1, ultimo=2, cant=1

                                Console.WriteLine("Última supresión, vaciando la cola...");
                                Console.WriteLine($"Suprimido 7 (Esperado 80): {cola.Suprimir()}"); // primero=2, ultimo=2, cant=0

                                Console.WriteLine("Estado final de la cola:");
                                Console.Write("Recorrido: ");
                                cola.Recorrer();
                                Console.WriteLine($"¿Está vacía? {cola.IsEmpty()} (Esperado: True)");

                                // Verificar que los punteros están en una posición válida después de vaciarse (primero=2, ultimo=2)
                                // Lo importante es que cant=0, indicando que está vacía.

                                // 7. Test de nueva inserción después de vaciado
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('=', 40));
                                Console.WriteLine("## 7. Reutilización de Cola Vacía");
                                cola.Insertar(99); // primero=2, ultimo=3, cant=1
                                Console.WriteLine("Insertado 99.");
                                Console.Write("Recorrido final (Esperado: 99): ");
                                cola.Recorrer();
                                break;


                            case "Cola Encadenada":
                                // Usamos un nombre de variable único: colaEnlTest
                                ColaEncadenada<int> colaEnlTest = new ColaEncadenada<int>();
                                Console.WriteLine("\n\n" + new string('*', 50));
                                Console.WriteLine("--- Test de Robustez de Cola Enlazada (ColaEncadenada) ---");
                                Console.WriteLine(new string('*', 50));

                                // 1. Test de Cola Vacía Inicial
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n## 1. Cola Vacía Inicial (Comprobación de Nulls)");
                                Console.WriteLine($"¿Está vacía? {colaEnlTest.IsEmpty()} (Esperado: True)");

                                Console.Write("Intento de suprimir de cola vacía: ");
                                int suprimidoVacioB = colaEnlTest.Suprimir();
                                Console.WriteLine($"(Valor devuelto: {suprimidoVacioB}, Esperado: 0 y mensaje 'Cola Vacia')");

                                Console.WriteLine("Recorrido de cola vacía (Esperado: Nada):");
                                colaEnlTest.Recorrer();

                                // 2. Test de Inserción (Enqueue) y Recorrido
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 2. Inserciones (Enqueue)");

                                Console.WriteLine("Insertando: 11, 22, 33...");
                                colaEnlTest.Insertar(11);
                                colaEnlTest.Insertar(22);
                                colaEnlTest.Insertar(33);

                                Console.WriteLine($"¿Está vacía? {colaEnlTest.IsEmpty()} (Esperado: False)");

                                Console.WriteLine("Recorrido (Esperado: 11, 22, 33 en orden FIFO):");
                                colaEnlTest.Recorrer();

                                // 3. Test de Supresión (Dequeue) y Comportamiento FIFO
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 3. Supresiones (Dequeue) y FIFO");

                                // Suprime 11 (FIFO)
                                int sup1A = colaEnlTest.Suprimir();
                                Console.WriteLine($"Suprimido 1 (Esperado 11): {sup1A}");

                                // Suprime 22 (FIFO)
                                int sup2B = colaEnlTest.Suprimir();
                                Console.WriteLine($"Suprimido 2 (Esperado 22): {sup2B}");

                                Console.WriteLine("Estado de la cola (Esperado: 33):");
                                colaEnlTest.Recorrer();

                                // 4. Test de Caso Límite: Cola con un solo elemento
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 4. Caso Límite: Único Elemento (primero y ultimo)");

                                // Suprimir el último elemento (33)
                                int sup3 = colaEnlTest.Suprimir();
                                Console.WriteLine($"Suprimido 3 (Esperado 33): {sup3}");

                                Console.WriteLine("Estado de la cola:");
                                colaEnlTest.Recorrer();
                                Console.WriteLine($"¿Está vacía? {colaEnlTest.IsEmpty()} (Esperado: True)");

                                // **CRÍTICO:** Verificar que 'ultimo' se actualice a null cuando 'primero' se hace null
                                // Esto previene errores de inserción posteriores.
                                Console.WriteLine("Intento de suprimir inmediatamente (debe mostrar Cola Vacia):");
                                colaEnlTest.Suprimir();

                                // 5. Test de Recarga después de Vaciado
                                // --------------------------------------------------------------------------------
                                Console.WriteLine("\n" + new string('-', 40));
                                Console.WriteLine("## 5. Recarga y Verificación del Puntero 'ultimo'");

                                // Insertar un nuevo elemento después de vaciarla.
                                // Esto prueba si 'ultimo' se manejó correctamente en la supresión anterior.
                                colaEnlTest.Insertar(44); // primero y ultimo deben apuntar a 44
                                Console.WriteLine("Insertado 44.");
                                colaEnlTest.Insertar(55);
                                Console.WriteLine("Insertado 55.");

                                Console.WriteLine("Recorrido (Esperado: 44, 55):");
                                colaEnlTest.Recorrer();

                                // Última comprobación FIFO
                                Console.WriteLine($"Suprimido (Esperado 44): {colaEnlTest.Suprimir()}");
                                Console.WriteLine($"Suprimido (Esperado 55): {colaEnlTest.Suprimir()}");

                                Console.WriteLine("\nCola vaciada con éxito. Fin del test.");
                                break;


                            case "Lista Cursores":
                                Console.WriteLine("--- INICIO DE PRUEBAS DE ROBUSTEZ PARA ListaCursores ---");

                                // 1. Inicializar la lista con capacidad 5 para facilitar el manejo de 'llena'
                                
                                ListaCursores lista = new ListaCursores(CAPACIDAD);

                                Console.WriteLine($"\n[INFO] Lista inicializada con capacidad: {CAPACIDAD}");
                                Console.WriteLine(lista.ImprimirLista());

                                // =========================================================================
                                // 1. Pruebas de Inserción (Casos 1, 2, 3, 4)
                                // =========================================================================
                                Console.WriteLine("\n\n--- 1. PRUEBAS DE INSERCIÓN ---");

                                // Caso 1: Inserción en lista vacía (Posición 0, Valor 10)
                                lista.Insertar(0, 10);
                                Console.WriteLine($"[TEST 1] Insertar(0, 10). Esperado: [10]");
                                Console.WriteLine(lista.ImprimirLista());

                                // Caso 2: Inserción al final (Posición 1, Valor 20)
                                lista.Insertar(1, 20);
                                Console.WriteLine($"\n[TEST 2] Insertar(1, 20). Esperado: [10, 20]");
                                Console.WriteLine(lista.ImprimirLista());

                                // Caso 3: Inserción al inicio (Posición 0, Valor 5)
                                lista.Insertar(0, 5);
                                Console.WriteLine($"\n[TEST 3] Insertar(0, 5). Esperado: [5, 10, 20]");
                                Console.WriteLine(lista.ImprimirLista());

                                // Caso 4: Inserción en medio (Posición 2, Valor 15)
                                lista.Insertar(2, 15);
                                Console.WriteLine($"\n[TEST 4] Insertar(2, 15). Esperado: [5, 10, 15, 20]");
                                Console.WriteLine(lista.ImprimirLista());

                                // Caso 5: Inserción al final (Usamos el último espacio disponible)
                                lista.Insertar(4, 25);
                                Console.WriteLine($"\n[TEST 5] Insertar(4, 25). Esperado: [5, 10, 15, 20, 25] (Lista Llena)");
                                Console.WriteLine(lista.ImprimirLista());


                                // Caso 6: Índice fuera de rango (index > cant) y Lista Llena
                                int resultado_err = lista.Insertar(6, 99);
                                Console.WriteLine($"\n[TEST 6] Insertar(6, 99). Esperado: -1 (Index fuera de rango/Lista Llena). Resultado: {resultado_err}");

                                resultado_err = lista.Insertar(2, 99);
                                Console.WriteLine($"[TEST 6.1] Insertar(2, 99). Esperado: -1 (Lista Llena). Resultado: {resultado_err}");


                                // =========================================================================
                                // 2. Pruebas de Eliminación (Casos 7, 8, 9, 10, 11)
                                // =========================================================================
                                Console.WriteLine("\n\n--- 2. PRUEBAS DE ELIMINACIÓN ---");
                                // Lista actual: [5, 10, 15, 20, 25]

                                // Caso 7: Eliminar al inicio (Posición 0, Valor 5)
                                int valor_el = lista.Eliminar(0);
                                Console.WriteLine($"[TEST 7] Eliminar(0). Valor Retornado: {valor_el}. Esperado: [10, 15, 20, 25]");
                                Console.WriteLine(lista.ImprimirLista()); // Verifica que 'inicio' cambie y el índice 5 vaya a 'libre'

                                // Caso 8: Eliminar del medio (Posición 1, Valor 15)
                                valor_el = lista.Eliminar(1);
                                Console.WriteLine($"\n[TEST 8] Eliminar(1). Valor Retornado: {valor_el}. Esperado: [10, 20, 25]");
                                Console.WriteLine(lista.ImprimirLista()); // Verifica la reconexión de punteros y que el índice 15 vaya a 'libre'

                                // Caso 9: Eliminar al final (Posición 2, Valor 25)
                                valor_el = lista.Eliminar(2);
                                Console.WriteLine($"\n[TEST 9] Eliminar(2). Valor Retornado: {valor_el}. Esperado: [10, 20]");
                                Console.WriteLine(lista.ImprimirLista()); // Verifica eliminación del último nodo.

                                // Limpiar el resto para Caso 10
                                lista.Eliminar(0); // Elimina 10. Lista: [20]
                                lista.Eliminar(0); // Elimina 20. Lista: []

                                // Caso 10: Lista Vacía (Underflow)
                                Console.WriteLine("\n[TEST 10] Lista vacía.");
                                Console.WriteLine(lista.ImprimirLista()); // Lista: []. Cant: 0.
                                valor_el = lista.Eliminar(0);
                                Console.WriteLine($"[TEST 10.1] Eliminar(0). Esperado: -1 (Lista Vacía). Resultado: {valor_el}");

                                // Caso 11: Índice fuera de rango (index >= cant)
                                valor_el = lista.Eliminar(5);
                                Console.WriteLine($"[TEST 11] Eliminar(5). Esperado: -1 (Index fuera de rango). Resultado: {valor_el}");


                                // =========================================================================
                                // 3. Pruebas de Robustez: Reutilización de Espacio (Casos 12, 13)
                                // =========================================================================
                                Console.WriteLine("\n\n--- 3. PRUEBAS DE ROBUSTEZ (Reutilización de Espacio) ---");

                                // El orden de los índices libres debería ser: 20 -> 15 -> 5 (ejemplo basado en nuestro escenario)

                                // Caso 12: Reutilización de Espacio
                                // Lista vacía. El primer índice libre DEBE ser el que se liberó último (LIFO).

                                // Insertamos 3 elementos. Deberían usar los primeros 3 índices de 'libre' (que son los eliminados).
                                lista.Insertar(0, 1);
                                lista.Insertar(1, 2);
                                lista.Insertar(2, 3);

                                Console.WriteLine($"[TEST 12] Insertar 1, 2, 3.");
                                Console.WriteLine(lista.ImprimirLista());
                                // Verifica: El nodo '1' debe usar el índice libre más reciente (20 en nuestro ejemplo).
                                //           El nodo '2' debe usar el siguiente índice libre (15 en nuestro ejemplo).
                                //           El nodo '3' debe usar el siguiente (5 en nuestro ejemplo).
                                //           El 'libre' actual debe ser el siguiente nodo libre no utilizado en la inicialización (índice 4).

                                // Caso 13: Eliminar el único nodo y verificar la liberación
                                lista = new ListaCursores(3); // Nueva lista para control
                                lista.Insertar(0, 77); // Inserta 77, usa índice 0. Inicio=0. Cant=1. Libre=1.
                                Console.WriteLine("\n[TEST 13.1] Lista [77] creada.");
                                Console.WriteLine(lista.ImprimirLista());

                                valor_el = lista.Eliminar(0); // Elimina 77.
                                Console.WriteLine($"[TEST 13.2] Eliminar(0). Valor: {valor_el}.");
                                Console.WriteLine(lista.ImprimirLista());
                                // Verifica: Cant es 0. Inicio es -1. El índice 0 debe ser el nuevo 'libre'.

                                Console.WriteLine("\n--- FIN DE PRUEBAS DE ROBUSTEZ ---");
                                break;

                            case "Arbol Binario de Busqueda":
                                app.DATs.arbolBinarioDeBusqueda.Test();

                                break;
                            default:
                                Console.WriteLine("Opcion no encontrada.");
                                break;
                        }
                        break;



                    case "Practico 2":
                        switch (opciones[1])
                        {
                            case "Ejercicio 2":
                                app.Practico2.Ej2.Start();
                                break;
                            case "Ejercicio 3":
                                app.Practico2.Ej3.Start();
                                break;
                            case "Ejercicio 4":

                                break;
                            case "Ejercicio 7":
                                app.Practico2.Ej7.Start(60);
                                break;
                            default:
                                Console.WriteLine("Opcion no encontrada.");
                                break;
                        }
                        break;



                    case "Practico 3":
                        switch (opciones[1])
                        {
                            case "ejercicio 1":
                                break;
                            case "ejercicio 2":
                                break;
                            default:
                                Console.WriteLine("Opcion no encontrada.");
                                break;
                        }
                        break;
                    
                    
                    
                    case "Practico 4":
                        switch(opciones[1]) //NOTA: REVISAR SI LOS EJERCICIOS DAN LOS RESULTADOS CORRECTOS
                        {
                            case "Ejercicio 2 - Inciso A":
                                app.Practico4.Ejercicio2.IncisoA();
                                break;
                            case "Ejercicio 2 - Inciso B":
                                app.Practico4.Ejercicio2.IncisoB();
                                break;
                            case "Ejercicio 2 - Inciso C":
                                app.Practico4.Ejercicio2.IncisoC();
                                break;
                            case "Ejercicio 2 - Inciso D":
                                app.Practico4.Ejercicio2.IncisoD();
                                break;

                            case "Ejercicio 3":
                                app.Practico4.Ejercicio3.Start();
                                break;

                            default:
                                Console.WriteLine("Opcion no encontrada.");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Opcion no encontrada.");
                        break;

                }
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }


        }
    }
}
