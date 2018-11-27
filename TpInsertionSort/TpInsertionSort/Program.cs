using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TpInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vetor = new int[10000];
            Random gerador = new Random();
            for (int i = 0; i < vetor.Length; ++i)//preenche vetor com numeros aleatorios
            {
                vetor[i] = gerador.Next(0, 10000);
            }

            int[] vetor2 = new int[10000];
            for (int i = 0; i <= vetor2.Length - 1; i++)//preenche o vetor de forma crescente
            {
                vetor2[i] = i;
            }

            int[] vetor3 = new int[10000];
            for (int i = vetor2.Length - 1; i >= 1; i--)//preenche o vetor de forma decrescente
            {
                vetor3[i] = i + 1;
            }

            Stopwatch time = new Stopwatch();

            time.Start();
            InsertionSort(vetor);
            time.Stop();
            TimeSpan time1 = time.Elapsed;
            time.Reset();

            time.Start();
            InsertionSort(vetor2);
            time.Stop();
            TimeSpan time2 = time.Elapsed;
            time.Reset();

            time.Start();
            InsertionSort(vetor3);
            time.Stop();
            TimeSpan time3 = time.Elapsed;

            Imprimir(vetor);
            Console.WriteLine("\nTempo no vetor aleatorio: " + time1.TotalMilliseconds + "\n");

            Imprimir(vetor2);
            Console.WriteLine("\nTempo no vetor crescente: " + time2.TotalMilliseconds + "\n");

            Imprimir(vetor3);
            Console.WriteLine("\nTempro no vetor decrescente: " + time3.TotalMilliseconds + "\n");


            Console.ReadKey(true);

        }

        static void InsertionSort(int[] vetor)
        {

            int n = vetor.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = vetor[i];
                int j = i - 1;

                // Move elementos do vetor[0..i-1], que são maiores que key para uma posição a frente de sua atual 
                while (j >= 0 && vetor[j] > key)
                {
                    vetor[j + 1] = vetor[j];
                    j = j - 1;
                }
                vetor[j + 1] = key;
            }
        }

        static void Imprimir(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(vetor[i] + " ");

            Console.Write("\n");
        }

    }
}
