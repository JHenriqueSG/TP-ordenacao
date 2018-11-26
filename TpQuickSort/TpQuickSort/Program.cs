using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TpQuickSort
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
            QuickSort(vetor, 0, vetor.Length - 1);
            time.Stop();
            TimeSpan time1 = time.Elapsed;
            time.Reset();

            time.Start();
            QuickSort(vetor2, 0, vetor2.Length - 1);
            time.Stop();
            TimeSpan time2 = time.Elapsed;
            time.Reset();

            time.Start();
            QuickSort(vetor3, 0, vetor3.Length - 1);
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

        static int Partição(int[] vetor, int menor, int maior)
        {
            int trava = vetor[maior];

            int i = (menor - 1);                 // index of smaller element 
            for (int j = menor; j < maior; j++)
            {

                if (vetor[j] <= trava)            // se o elemento atual é menor que ou igual ao pivo 
                {
                    i++;

                    int temp = vetor[i];         // swap arr[i] and arr[j]  
                    vetor[i] = vetor[j];
                    vetor[j] = temp;
                }
            }

            int temp1 = vetor[i + 1];            // swap arr[i+1] and arr[high] (or pivot) 
            vetor[i + 1] = vetor[maior];
            vetor[maior] = temp1;

            return i + 1;
        }

        static void QuickSort(int[] vetor, int menor, int maior)
        {
            if (menor < maior)
            {

                int pi = Partição(vetor, menor, maior);     /* pi is partitioning index, arr[pi] is now at right place */

                QuickSort(vetor, menor, maior - 1);            // Recursively sort elements before partition and after partition 
                QuickSort(vetor, pi + 1, maior);
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
