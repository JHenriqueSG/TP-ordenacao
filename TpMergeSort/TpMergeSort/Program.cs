using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TpMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vetor1 = new int[10000];
            Random gerador = new Random();
            for (int i = 0; i < vetor1.Length; i++)//preenche vetor com numeros aleatorios
            {
                vetor1[i] = gerador.Next(0, 10000);
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
            vetor1 = mergeSort(vetor1);
            time.Stop();
            TimeSpan time1 = time.Elapsed;
            time.Reset();

            time.Start();
            mergeSort(vetor2);
            time.Stop();
            TimeSpan time2 = time.Elapsed;
            time.Reset();

            time.Start();
            vetor3 = mergeSort(vetor3);
            time.Stop();
            TimeSpan time3 = time.Elapsed;

            Imprimir(vetor1);
            Console.WriteLine("\nTempo no vetor aleatorio: " + time1.TotalMilliseconds + "\n");

            Imprimir(vetor2);
            Console.WriteLine("\nTempo no vetor crescente: " + time2.TotalMilliseconds + "\n");

            Imprimir(vetor3);
            Console.WriteLine("\nTempo no vetor decrescente: " + time3.TotalMilliseconds + "\n");
            

            Console.ReadKey(true);


        }

        public static int[] mergeSort(int[] vetor)
        {
            int[] left;
            int[] right;
            int[] result = new int[vetor.Length];

            //As this is a recursive algorithm, we need to have a base case to avoid an infinite 
            //recursion and therfore a stackoverflow  
            if (vetor.Length <= 1)
                return vetor;

            // The exact midpoint of our array  
            int midPoint = vetor.Length / 2;

            //Will represent our 'left' array  
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of elements  
            if (vetor.Length % 2 == 0)
                right = new int[midPoint];

            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];

            //populate left array  
            for (int i = 0; i < midPoint; i++)
                left[i] = vetor[i];

            //populate right array          
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < vetor.Length; i++)
            {
                right[x] = vetor[i];
                x++;
            }

            //Recursively sort the left array  
            left = mergeSort(left);
            //Recursively sort the right array  
            right = mergeSort(right);
            //Merge our two sorted arrays  
            result = merge(left, right);

            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array  
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //  
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //while either array still has an element  
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array  
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array  
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array  
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array  
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }

            }
            return result;
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
