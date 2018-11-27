using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TpBubbleSort
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
            bubbleSort(vetor);
            time.Stop();
            TimeSpan time1 = time.Elapsed;
            time.Reset();

            time.Start();
            bubbleSort(vetor2);
            time.Stop();
            TimeSpan time2 = time.Elapsed;
            time.Reset();

            time.Start();
            bubbleSort(vetor3);
            time.Stop();
            TimeSpan time3 = time.Elapsed;
   
            Imprimir(vetor);
            Console.WriteLine("\nTempo no vetor aleatorio: " + time1.TotalMilliseconds +"\n");

            Imprimir(vetor2);
            Console.WriteLine("\nTempo no vetor crescente: " + time2.TotalMilliseconds + "\n");

            Imprimir(vetor3);
            Console.WriteLine("\nTempro no vetor decrescente: " + time3.TotalMilliseconds + "\n");


            Console.ReadKey(true);

        }
        static void bubbleSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (vetor[j] > vetor[j + 1])
                    {
                        // troca temp e vetor[i] 
                        int temp = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = temp;
                    }
        }


        /* imprime o vetor */
        static void Imprimir(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(vetor[i] + " ");
            Console.WriteLine();
        }


    }
}
