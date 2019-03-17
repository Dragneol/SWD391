using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortTracker
{
    class Program
    {
        const int MAX_NUM = 100000;
        static int[] winners = new int[MAX_NUM];
        static void PrintArr(long[] inputArray)
        {
            foreach (var item in inputArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void win(int i, int algorithm)
        {
            if (winners[i] == 0)
            {
                winners[i] = algorithm;

                if (i < MAX_NUM - 1)
                {
                    race(++i);
                }
            }
        }
        static void race(int i)
        {
            long[] inputArray = new long[MAX_NUM];
            Random rnd = new Random();
            for (int j = 0; j < inputArray.Length; j++)
            {
                inputArray[j] = rnd.Next(MAX_NUM) + 1;
            }

            Thread t1 = new Thread(() =>
            {
                DateTime start = DateTime.Now;
                long[] arr1 = (long[])inputArray.Clone();
                MergeSort(arr1);
                win(i, 1);
                DateTime end = DateTime.Now;
                Console.WriteLine("MergeSort Done " + end.Subtract(start).TotalMilliseconds);

            });

            Thread t2 = new Thread(() =>
            {
                DateTime start = DateTime.Now;
                long[] arr2 = (long[])inputArray.Clone();
                ShellSort(arr2);
                win(i, 2);
                DateTime end = DateTime.Now;
                Console.WriteLine("ShellSort Done " + end.Subtract(start).TotalMilliseconds);
            });


            Thread t3 = new Thread(() =>
            {
                DateTime start = DateTime.Now;
                long[] arr3 = (long[])inputArray.Clone();
                InsertionSort(arr3);
                DateTime end = DateTime.Now;
                Console.WriteLine("Insertion Done " + end.Subtract(start).TotalMilliseconds);
            });

            t1.Start();
            t2.Start();
            t3.Start();

        }
        static void Main(string[] args)
        {
            new Thread(() => race(0)).Start();
            Console.ReadLine();
        }
        static void MergeSort(long[] inputArray)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            InternalMergeSort(inputArray, left, right);
        }
        static void ShellSort(long[] inputArray)
        {
            long j, temp = 0;
            int increment = (inputArray.Length) / 2;
            while (increment > 0)
            {
                for (int index = 0; index < inputArray.Length; index++)
                {
                    j = index;
                    temp = inputArray[index];
                    while ((j >= increment) && inputArray[j - increment] > temp)
                    {
                        inputArray[j] = inputArray[j - increment];
                        j = j - increment;
                    }
                    inputArray[j] = temp;
                }
                if (increment / 2 != 0)
                    increment = increment / 2;
                else if (increment == 1)
                    increment = 0;
                else
                    increment = 1;
            }
        }
        static void InsertionSort(long[] inputArray)
        {
            long j = 0;
            long temp = 0;
            for (int index = 1; index < inputArray.Length; index++)
            {
                j = index;
                temp = inputArray[index];
                while ((j > 0) && (inputArray[j - 1] > temp))
                {
                    inputArray[j] = inputArray[j - 1];
                    j = j - 1;
                }
                inputArray[j] = temp;
            }
        }
        static void BubbleSort(long[] inputArray)
        {
            for (int iterator = 0; iterator < inputArray.Length; iterator++)
            {
                for (int index = 0; index < inputArray.Length - 1; index++)
                {
                    if (inputArray[index] > inputArray[index + 1])
                    {
                        Swap(ref inputArray[index], ref inputArray[index + 1]);
                    }
                }
            }
        }
        static void HeapSort(long[] inputArray)
        {
            for (int index = (inputArray.Length / 2) - 1; index >= 0; index--)
                Heapify(inputArray, index, inputArray.Length);
            for (int index = inputArray.Length - 1; index >= 1; index--)
            {
                SwapWithTemp(ref inputArray[0], ref inputArray[index]);
                Heapify(inputArray, 0, index - 1);
            }
        }
        static void SelectionSort(long[] inputArray)
        {
            long index_of_min = 0;
            for (int iterator = 0; iterator < inputArray.Length - 1; iterator++)
            {
                index_of_min = iterator;
                for (int index = iterator + 1; index < inputArray.Length; index++)
                {
                    if (inputArray[index] < inputArray[index_of_min])
                        index_of_min = index;
                }
                Swap(ref inputArray[iterator], ref inputArray[index_of_min]);
            }
        }
        static void QuickSort(long[] inputArray)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            InternalQuickSort(inputArray, left, right);
        }
        static void InternalQuickSort(long[] inputArray, int left, int right)
        {
            int pivotNewIndex = Partition(inputArray, left, right);
            long pivot = inputArray[(left + right) / 2];
            if (left < pivotNewIndex - 1)
                InternalQuickSort(inputArray, left, pivotNewIndex - 1);
            if (pivotNewIndex < right)
                InternalQuickSort(inputArray, pivotNewIndex, right);
        }
        //This operation returns a new pivot everytime it is called recursively
        //and swaps the array elements based on pivot value comparison
        static int Partition(long[] inputArray, int left, int right)
        {
            int i = left, j = right;
            long pivot = inputArray[(left + right) / 2];

            while (i <= j)
            {
                while (inputArray[i] < pivot)
                    i++;
                while (inputArray[j] < pivot)
                    j--;
                if (i <= j)
                {
                    SwapWithTemp(ref inputArray[i], ref inputArray[j]);
                    i++; j--;
                }
            }
            return i;
        }
        static void Swap(ref long valOne, ref long valTwo)
        {
            valOne = valOne + valTwo;
            valTwo = valOne - valTwo;
            valOne = valOne - valTwo;
        }
        static void SwapWithTemp(ref long valOne, ref long valTwo)
        {
            long temp = valOne;
            valOne = valTwo;
            valTwo = temp;
        }
        static void MergeSortedArray(long[] inputArray, int left, int mid, int right)
        {
            int index = 0;
            int total_elements = right - left + 1; //BODMAS rule
            int right_start = mid + 1;
            int temp_location = left;
            long[] tempArray = new long[total_elements];

            while ((left <= mid) && right_start <= right)
            {
                if (inputArray[left] <= inputArray[right_start])
                {
                    tempArray[index++] = inputArray[left++];
                }
                else
                {
                    tempArray[index++] = inputArray[right_start++];
                }
            }
            if (left > mid)
            {
                for (int j = right_start; j <= right; j++)
                    tempArray[index++] = inputArray[right_start++];
            }
            else
            {
                for (int j = left; j <= mid; j++)
                    tempArray[index++] = inputArray[left++];
            }
            //Array.Copy(tempArray, 0, inputArray, temp_location, total_elements);
            // just another way of accomplishing things (in-built copy)
            for (int i = 0, j = temp_location; i < total_elements; i++, j++)
            {
                inputArray[j] = tempArray[i];
            }
        }
        static void InternalMergeSort(long[] inputArray, int left, int right)
        {
            int mid = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                InternalMergeSort(inputArray, left, mid);
                InternalMergeSort(inputArray, (mid + 1), right);
                MergeSortedArray(inputArray, left, mid, right);
            }
        }
        static void Heapify(long[] inputArray, int root, int bottom)
        {
            bool completed = false;
            int maxChild;

            while ((root * 2 <= bottom) && (!completed))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (inputArray[root * 2] > inputArray[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                if (inputArray[root] < inputArray[maxChild])
                {
                    SwapWithTemp(ref inputArray[root], ref inputArray[maxChild]);
                    root = maxChild;
                }
                else
                {
                    completed = true;
                }
            }
        }

    }
}
