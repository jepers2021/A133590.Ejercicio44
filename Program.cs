using System;
using System.Collections.Generic;

namespace A133590.Ejercicio44
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 44");
            List<string> lista = new List<string>();
            while(true)
            {
                Console.Write("> ");
                string comando = Console.ReadLine().Trim();
                if (comando.Length == 0)
                {
                    Console.WriteLine("Comando inválido.");
                    continue;
                }
                string[] cadenasComando = comando.Split();

                

                switch(cadenasComando[0])
                {
                    case "alta":
                        if (cadenasComando.Length < 2)
                        {
                            Console.WriteLine("Comando correcto, error de sintaxis.");
                            break;
                        }
                        if (!lista.Contains(cadenasComando[1]))
                        {
                            bool exito = true;
                            foreach(char c in cadenasComando[1]) exito &= Char.IsLetter(c);

                            if (exito) lista.Add(cadenasComando[1]);
                            else Console.WriteLine("No se admiten caracteres especiales o dígitos en los nombres.");
                        }
                        break;
                    case "baja":
                        if (cadenasComando.Length < 2)
                        {
                            Console.WriteLine("Comando correcto, error de sintaxis.");
                            break;
                        }
                        int indice = -1;
                        if(Int32.TryParse(cadenasComando[1], out indice))
                        {
                            if(indice > 0 && indice < lista.Count)
                            {
                                string aux = lista[indice];
                                lista.RemoveAt(indice);
                                Console.WriteLine($"El nombre {aux} fue eliminado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Error: Número fuera del rango de la lista");
                            }
                        } 
                        else if (lista.Contains(cadenasComando[1]))
                        {
                            lista.Remove(cadenasComando[1]);
                            Console.WriteLine($"El nombre {cadenasComando[1]} fue eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Error: Nombre no disponible en la lista.");
                        }
                        break;
                    case "mostrar":
                        foreach (string s in lista) Console.WriteLine(s);
                        break;
                    case "fin":
                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Comando inválido. Comandos disponibles: ");
                        Console.WriteLine("alta [Nombre]");
                        Console.WriteLine("baja [índice|nombre]");
                        Console.WriteLine("mostrar");
                        Console.WriteLine("fin");
                        break;
                }
                
                
            }
        }
    }
}
