using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Menu
    {
        public string Show()
        {
            string option = "";

            var menus = new Dictionary<string, string[]>
            {
                { "Main", new[] { "Testear Estructuras", "Practico 2", "Practico 3", "Practico 4", "Salir" } },
                { "Testear Estructuras", new[] { "Pila Encadenada", "Lista Enlazada Ordenada", "Pila Secuencial", "Cola Secuencial", "Cola Encadenada", "Lista Secuencial", "Lista Enlazada", "Lista Cursores","Arbol Binario de Busqueda", "Regresar" } },
                { "Practico 2", new[] { "Ejercicio 2", "Ejercicio 3", "Ejercicio 4", "Ejercicio 7", "Regresar" } },
                { "Practico 3", new[] { "Ejercicio 1", "Ejercicio 2", "Ejercicio 3", "Ejercicio 4", "Ejercicio 5", "Regresar" } },
                { "Practico 4", new[] { "Ejercicio 2 - Inciso A", "Ejercicio 2 - Inciso B", "Ejercicio 2 - Inciso C", "Ejercicio 2 - Inciso D", "Ejercicio 3", "Regresar"} }
            };

            string currentMenu = "Main";
            string[] options = menus[currentMenu];


            int optionSelected = 1;
            bool selection = false;
            while (option == "")
            {
                Console.Clear();

                do
                {
                    Debug.WriteLine("Cambiando opcion...");
                    DrawOptions(optionSelected, options);
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.UpArrow:
                            optionSelected--;
                            break;
                        case ConsoleKey.DownArrow:
                            optionSelected++;
                            break;
                        case ConsoleKey.Enter:
                            option = options[optionSelected - 1];  //guardamos la opcion seleccionada
                            selection = true;
                            break;
                    }

                    if (optionSelected > options.Length) optionSelected--;
                    else if (optionSelected < 1) optionSelected++;
                }
                while (!selection);

                if (option == "Regresar") 
                {
                    if (currentMenu != "Main") //Si no estamos en el menu principal, volvemos a el
                    {
                        currentMenu = "Main";
                        options = menus[currentMenu];
                        optionSelected = 1;
                        option = "";
                        selection = false;
                    }
                   
                }
                else if (menus.ContainsKey(option)) //Si la opcion seleccionada es un submenu, entramos en el
                {
                    currentMenu = option;
                    options = menus[currentMenu];
                    optionSelected = 1;
                    option = "";
                    selection = false;
                }
                else if (option == "Salir") Environment.Exit(0);  //Si la opcion es salir, cerramos la aplicacion
                else break;


                //Si no es un submenu, devolvemos la opcion seleccionada

            }
            option = $"{currentMenu}/{option}"; //Devolvemos el menu y la opcion seleccionada
            return option;
        }



        private void DrawOptions(int optionselected, string[] options)
        {
            //Se eliminan los nombres en blanco. No deberian haber.
            options = options.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            int xInit = 41, yInit = 4;
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(xInit, yInit + i * 2);
                Console.WriteLine($"{(optionselected == i + 1 ? "     >" : "      ")} {options[i].ToString()}");
                Console.SetCursorPosition(xInit, yInit + 1 + i);
                Console.WriteLine(" ");
            }
        }



    }
}
