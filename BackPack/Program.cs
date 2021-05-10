using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPack
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] value ={ 60, 100, 120 };     // вартість предметів
            //int[] weight = { 10, 20, 30 };       // вага предметів
            //int capacity = 50;                           // місткість рюкзака
            //int itemsCount = 3;                        // кількість предметів

            int[] value = { 3,4,5,8,9};     // вартість предметів
            int[] weight = { 1,6,4,7,6 };       // вага предметів
            int capacity = 13;                           // місткість рюкзака
            int itemsCount = 5;                        // кількість предметів
            int result = KnapSack(capacity, weight, value, itemsCount);
            Console.WriteLine(result);
        }

        static int KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount+1, capacity+1];

            for (int i = 0; i <= itemsCount; i++) //проходимось по предметах
            {
                for (int w = 0; w <= capacity; w++) //проходимось по місткості рюкзака
                {
                    if (i == 0 || w == 0) //Первые элементы приравниваем к 0
                    {
                        K[i, w] = 0;
                    }
                    else if (weight[i - 1] <= w) //Если текущий предмет вмещается в рюкзак
                    {
                        int a = value[i - 1] + K[i - 1, w - weight[i - 1]];
                        int b = K[i - 1, w];
                        K[i, w] = a > b ? a : b; //Выбираем класть его или нет
                    }
                    else //Иначе, не кладем 
                    {
                        K[i, w] = K[i - 1, w];
                    }
                    Console.Write(K[i, w] + "\t");
                }
                Console.WriteLine();
            }
            return K[itemsCount, capacity];
        }

    }
}
