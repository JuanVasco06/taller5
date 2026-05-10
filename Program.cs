using System;

namespace TallerListasLigadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDobleLigada<string> lista = new ListaDobleLigada<string>();

            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== MENÚ LISTA DOBLEMENTE LIGADA =====");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = LeerEntero();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el elemento a adicionar: ");
                        string datoAdicionar = Console.ReadLine() ?? "";
                        lista.Adicionar(datoAdicionar);
                        Console.WriteLine("Elemento adicionado correctamente.");
                        break;

                    case 2:
                        lista.MostrarHaciaAdelante();
                        break;

                    case 3:
                        lista.MostrarHaciaAtras();
                        break;

                    case 4:
                        lista.OrdenarDescendentemente();
                        Console.WriteLine("La lista fue ordenada descendentemente.");
                        break;

                    case 5:
                        lista.MostrarModas();
                        break;

                    case 6:
                        lista.MostrarGrafico();
                        break;

                    case 7:
                        Console.Write("Ingrese el elemento a buscar: ");
                        string datoBuscar = Console.ReadLine() ?? "";

                        if (lista.Existe(datoBuscar))
                        {
                            Console.WriteLine("Sí existe el elemento: " + datoBuscar);
                        }
                        else
                        {
                            Console.WriteLine("No existe el elemento: " + datoBuscar);
                        }
                        break;

                    case 8:
                        Console.Write("Ingrese el elemento para eliminar una ocurrencia: ");
                        string datoEliminarUno = Console.ReadLine() ?? "";
                        lista.EliminarUnaOcurrencia(datoEliminarUno);
                        break;

                    case 9:
                        Console.Write("Ingrese el elemento para eliminar todas las ocurrencias: ");
                        string datoEliminarTodos = Console.ReadLine() ?? "";
                        lista.EliminarTodasLasOcurrencias(datoEliminarTodos);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 0);
        }

        static int LeerEntero()
        {
            int numero;

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Debe ingresar un número válido: ");
            }

            return numero;
        }
    }
}