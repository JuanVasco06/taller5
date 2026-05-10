using System;

namespace TallerListasLigadas
{
    public class ListaDobleLigada<T> where T : IComparable<T>
    {
        private Nodo<T>? cabeza;
        private Nodo<T>? cola;

        public ListaDobleLigada()
        {
            cabeza = null;
            cola = null;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        /*
         * Adiciona elementos manteniendo la lista en orden ascendente.
         * Puede recibir elementos repetidos.
         */
        public void Adicionar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);

            if (EstaVacia())
            {
                cabeza = nuevo;
                cola = nuevo;
                return;
            }

            if (dato.CompareTo(cabeza!.Dato) <= 0)
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
                return;
            }

            if (dato.CompareTo(cola!.Dato) >= 0)
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
                return;
            }

            Nodo<T>? actual = cabeza;

            while (actual != null && dato.CompareTo(actual.Dato) > 0)
            {
                actual = actual.Siguiente;
            }

            Nodo<T>? anterior = actual!.Anterior;

            anterior!.Siguiente = nuevo;
            nuevo.Anterior = anterior;

            nuevo.Siguiente = actual;
            actual.Anterior = nuevo;
        }

        public void MostrarHaciaAdelante()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cabeza;

            Console.Write("Lista hacia adelante: ");

            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Siguiente;
            }

            Console.WriteLine();
        }

        public void MostrarHaciaAtras()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cola;

            Console.Write("Lista hacia atrás: ");

            while (actual != null)
            {
                Console.Write(actual.Dato + " ");
                actual = actual.Anterior;
            }

            Console.WriteLine();
        }

        /*
         * Cambia el orden de la lista a descendente invirtiendo los enlaces.
         */
        public void OrdenarDescendentemente()
        {
            if (EstaVacia() || cabeza == cola)
            {
                return;
            }

            Nodo<T>? actual = cabeza;
            Nodo<T>? temporal = null;

            while (actual != null)
            {
                temporal = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temporal;

                actual = actual.Anterior;
            }

            temporal = cabeza;
            cabeza = cola;
            cola = temporal;
        }

        public bool Existe(T dato)
        {
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public void EliminarUnaOcurrencia(T dato)
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    EliminarNodo(actual);
                    Console.WriteLine("Se eliminó una ocurrencia de: " + dato);
                    return;
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine("No se encontró el elemento: " + dato);
        }

        public void EliminarTodasLasOcurrencias(T dato)
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cabeza;
            int contador = 0;

            while (actual != null)
            {
                Nodo<T>? siguiente = actual.Siguiente;

                if (actual.Dato.CompareTo(dato) == 0)
                {
                    EliminarNodo(actual);
                    contador++;
                }

                actual = siguiente;
            }

            if (contador > 0)
            {
                Console.WriteLine("Se eliminaron " + contador + " ocurrencia(s) de: " + dato);
            }
            else
            {
                Console.WriteLine("No se encontró el elemento: " + dato);
            }
        }

        private void EliminarNodo(Nodo<T> nodo)
        {
            if (nodo == cabeza && nodo == cola)
            {
                cabeza = null;
                cola = null;
            }
            else if (nodo == cabeza)
            {
                cabeza = cabeza!.Siguiente;
                cabeza!.Anterior = null;
            }
            else if (nodo == cola)
            {
                cola = cola!.Anterior;
                cola!.Siguiente = null;
            }
            else
            {
                nodo.Anterior!.Siguiente = nodo.Siguiente;
                nodo.Siguiente!.Anterior = nodo.Anterior;
            }
        }

        public void MostrarModas()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            int frecuenciaMaxima = 0;
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                int frecuencia = ContarOcurrencias(actual.Dato);

                if (frecuencia > frecuenciaMaxima)
                {
                    frecuenciaMaxima = frecuencia;
                }

                actual = actual.Siguiente;
            }

            Console.Write("Moda(s): ");
            actual = cabeza;

            while (actual != null)
            {
                T datoActual = actual.Dato;
                int frecuencia = ContarOcurrencias(datoActual);

                if (frecuencia == frecuenciaMaxima && !YaFueMostrado(datoActual, actual))
                {
                    Console.Write(datoActual + " ");
                }

                actual = actual.Siguiente;
            }

            Console.WriteLine();
            Console.WriteLine("Frecuencia máxima: " + frecuenciaMaxima);
        }

        private int ContarOcurrencias(T dato)
        {
            int contador = 0;
            Nodo<T>? actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.CompareTo(dato) == 0)
                {
                    contador++;
                }

                actual = actual.Siguiente;
            }

            return contador;
        }

        private bool YaFueMostrado(T dato, Nodo<T> limite)
        {
            Nodo<T>? actual = cabeza;

            while (actual != limite)
            {
                if (actual!.Dato.CompareTo(dato) == 0)
                {
                    return true;
                }

                actual = actual.Siguiente;
            }

            return false;
        }

        public void MostrarGrafico()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo<T>? actual = cabeza;

            Console.WriteLine("Gráfico de ocurrencias:");

            while (actual != null)
            {
                T datoActual = actual.Dato;

                if (!YaFueMostrado(datoActual, actual))
                {
                    int frecuencia = ContarOcurrencias(datoActual);

                    Console.Write(datoActual + " ");

                    for (int i = 0; i < frecuencia; i++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();
                }

                actual = actual.Siguiente;
            }
        }
    }
}