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


            //Como este é um algoritmo recursivo, precisamos ter um caso base para evitar um loop infinito e, portanto, um stackoverflow
            if (vetor.Length <= 1)
                return vetor;

            // encontra a metade do vetor  
            int midPoint = vetor.Length / 2;

            //ira representar o 'lado esquerdo' do vetor  
            left = new int[midPoint];

            //Se o vetor tiver um número par de elementos, o vetor da esquerda e da direita terao o mesmo número de elementos
            if (vetor.Length % 2 == 0)
                right = new int[midPoint];

            //se o vetor tiver um número ímpar de elementos, o vetor direito terá um elemento a mais do que o esquerdo
            
            else
                right = new int[midPoint + 1];

            //preenche o vetor esquerdo
            for (int i = 0; i < midPoint; i++)
                left[i] = vetor[i];

            //preenche o vetor direito          
            int x = 0;
            //Começamos nosso índice a partir da metade, já que já preenchemos o vetor à esquerda de 0 a metade
            for (int i = midPoint; i < vetor.Length; i++)
            {
                right[x] = vetor[i];
                x++;
            }

            //Recursivamente organiza o detor a esquerda 
            left = mergeSort(left);
            //Recursivamente organiza o detor a direita 
            right = mergeSort(right);
            //Mescla os dois vetores ordenados 
            result = merge(left, right);

            return result;
        }

        //Este método será responsável por combinar nossos dois vetores ordenados em um vetor gigante
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //  enquanto qualquer vetor ainda tem um elemento
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //se ambos os vetores tiverem elementos  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //Se o item no vetor à esquerda for menor que o item no vetor a direit, adicione esse item ao vetor de resultados

                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // senão o item no vetor correto será adicionado ao vetor de resultados

                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //se apenas o vetor esquerdo ainda tiver elementos, adicione todos os itens ao vetor de resultados

                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //se apenas o array direito ainda tiver elementos, adicione todos os itens ao array de resultados

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
