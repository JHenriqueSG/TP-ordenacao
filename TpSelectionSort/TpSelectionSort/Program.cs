﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TpSelectionSort
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
            SelectionSort(vetor);
            time.Stop();
            TimeSpan time1 = time.Elapsed;
            time.Reset();

            time.Start();
            SelectionSort(vetor2);
            time.Stop();
            TimeSpan time2 = time.Elapsed;
            time.Reset();

            time.Start();
            SelectionSort(vetor3);
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

        static void SelectionSort(int[] Vetor)
        {
            int menor, i, j, aux;
            for (i = 0; i < Vetor.Length - 1; i++)
            {
                menor = i;
                for (j = i; j < Vetor.Length; j++)
                {
                    if (Vetor[j] < Vetor[menor])
                        menor = j;
                    aux = Vetor[menor];
                    Vetor[menor] = Vetor[i];
                    Vetor[i] = aux;
                }
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
