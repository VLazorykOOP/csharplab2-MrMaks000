using System;

namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 2 !");

            while (true)
            {
                Console.WriteLine("\nВведiть номер завдання");
                int NumberOfTask = Convert.ToInt32(Console.ReadLine());

                switch (NumberOfTask)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    default: break;
                }
            }
        }

        static void Task1()
        {          
            int[] array1D = InputeArray(0);
            int[,] array2D = InputeArray(0, 0);

            Console.WriteLine("Введiть початковий iндекс iнтервалу:");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiнцевий iндекс iнтервалу:");
            int end = Convert.ToInt32(Console.ReadLine());

            if (start >= array1D.Length || end >= array1D.Length || start > end)
            {
                Console.WriteLine($"Iндекси [{start}, {end}] поза зоною розмiрностi масиву");
                return;
            }

            int sum1D = CalculateSum(array1D, start, end);
            int sum2D = CalculateSum(array2D, start, end);

            Console.WriteLine($"Сума елементiв одновимiрного масиву в iнтервалi [{start}, {end}] = {sum1D}");
            Console.WriteLine($"Сума елементiв двовимiрного масиву в iнтервалi [{start}, {end}] = {sum2D}");
        }

        static int CalculateSum(int[] array, int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {                            
                sum += array[i];               
            }
            return sum;
        }

        static int CalculateSum(int[,] array, int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    sum += array[i, j];
                }
            }
            return sum;
        }

        static int[] InputeArray(int length)
        {
            if (length == 0)
            {
                Console.WriteLine("Введiть розмiрнiсть масиву:");
                length = Convert.ToInt32(Console.ReadLine());
            }

            int[] array = new int[length]; ;
            Console.WriteLine("Введiть елементи одновимiрного масиву:");
            for (int i = 0; i < length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }

        static int[,] InputeArray(int width, int length)
        {
            if (length == 0)
            {
                Console.WriteLine("Введiть довжину масиву:");
                length = Convert.ToInt32(Console.ReadLine());
            }

            if (width == 0)
            {
                Console.WriteLine("Введiть ширина масиву:");
                width = Convert.ToInt32(Console.ReadLine());
            }

            int[,] array = new int[width, length]; ;
            Console.WriteLine("Введiть елементи двовимiрного масиву:");
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
            }

            return array;
        }


        static void Task2() 
        {
            int[] array = InputeArray(0);

            int minIndex = 0;
            int maxIndex = 0;
            int minValue = array[0];
            int maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                    minIndex = i;
                }
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }

            if (maxIndex < minIndex)
            {
                Console.WriteLine("Максимальний елемент зустрiчається пiзнiше мiнiмального.");
                return;
            }

            int sum = 0;
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"Сума елементiв, розташованих мiж мiнiмальним ({minValue}) та максимальним ({maxValue}) елементами: {sum}");
        }

        static void Task3()
        {
            int[,] array = InputeArray(0, 0);

            if (array.GetLength(0) != array.GetLength(1))
            {
                Console.WriteLine("Кiлькiсть рядкiв у масивi не спiвпадає з кiлькiстю стовпчикiв.");
                return;
            }

            int length = array.GetLength(0);

            if (length % 2 != 0)
            {
                Console.WriteLine("Кiлькiсть рядкiв у масивi непарна, тому масив залишається без змiн.");
                PrintArray(array);
                return;
            }

            Console.WriteLine("Масив до змiни рядкiв:");
            PrintArray(array);

            for (int i = 0; i < length; i += 2)
            {
                for (int j = 0; j < length; j++)
                {
                    int temp = array[i, j];
                    array[i, j] = array[i + 1, j];
                    array[i + 1, j] = temp;
                }
            }

            Console.WriteLine("Масив пiсля змiни рядкiв:");
            PrintArray(array);
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Task4()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв у масивi:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] array = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Пiдмасив {i + 1}:");
                int[] subarray = InputeArray(0);
                if (subarray.Length > n)
                {
                    Console.WriteLine("Неправильна розмiрнiсть пiдмасиву.");
                    return;
                }
                array[i] = subarray;                            
                
            }

            int[] result = new int[n];
            int lastOddIndex = 0;

            for (int j = 0; j < n; j++)
            {
                lastOddIndex = -1;
                for (int i = 0; i < array[j].Length; i++)
                {
                    if (array[j][i] % 2 != 0)
                    {
                        lastOddIndex = i;
                    }
                }
                result[j] = lastOddIndex;
            }

            Console.WriteLine("Номери останнiх непарних елементiв у кожному стовпцi:");
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"Стовпець {j + 1}: {result[j]}");
            }
        }
    }
}
