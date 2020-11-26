using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BestEqualSubarray
{
    class Program
    {
        static void FillArray(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.WriteLine("Enter element {0}:", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        static void Print(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        static void FindMaxEqualSubArray(int[] array,out int startIndex,out int maxLength)
        {
            int counter = 0, length, i;
            startIndex = 0;
            maxLength = 1;
            while(counter<array.Length-1)
            {
                length = 1;
                i = counter + 1;
                while(i<array.Length)
                {
                    if(IsEqual(array[counter],array[i])==true)
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }
                    i++;
               
                FindStartIndexAndMaxLength(ref startIndex, ref maxLength, length, counter);
                counter = i;
                
            }
        }
        static void FindStartIndexAndMaxLength(ref int startIndex,ref int maxLength,int length,int counter)
        {
            if(length>maxLength)
            {
                startIndex = counter;
                maxLength = length;
            }
        }
        static bool IsEqual(int a,int b)
        {
            return a == b;
        }
        static void PrintMaxSubArray(int[] array,int startIndex,int maxLength)
        {
            Console.WriteLine("Maximum equal subarray is:");
            for(int i=startIndex;i<(startIndex+maxLength);i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        static void Main()
        {
            int n, startIndex, maxLength;
            Console.WriteLine("Enter number of elements in the array:");
            n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            FillArray(array);
            Print(array);
            Console.WriteLine();
            FindMaxEqualSubArray(array, out startIndex, out maxLength);
            PrintMaxSubArray(array, startIndex, maxLength);
        }
    }
}
