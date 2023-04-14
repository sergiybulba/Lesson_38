/* C#, lesson_38  01.04.2023																																					
																																					
Task № 3:																																					
Створіть інтерфейс ICalc2. У ньому мають бути два методи:																																					
¦ int CountDistinct() — повертає кількість унікальних значень у контейнері даних;																																					
¦ int EqualToValue(int valueToCompare) — повертає кількість значень, рівних valueToCompare.																																					
Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс ICalc2.																																					
Метод CountDistinct — повертає кількість унікальних значень в масив.																																					
Метод EqualToValue — повертає кількість елементів масиву, рівних valueToCompare.																																					
Напишіть код для тестування отриманої функціональності. */
//--------------------------------------------------------------------------------------------------------																																					
using System;
using System.Globalization;

namespace Lesson_38
{
    //--------------------------------------------------------------------------------------------------------																																					

    interface ICalc2                             // інтерфейс																																					
    {
        int CountDistinct();
        int EqualToValue(int valueToCompare);
    }

    //--------------------------------------------------------------------------------------------------------																																					
    class MyArray : ICalc2                      // оголошення класу																																					
    {
        private int[] _massyv;
        private int _size;

        public MyArray()                        // конструктор по замовчуванню																																					
        {
            this._size = 0;
            this._massyv = null;
        }

        public MyArray(int size)                // конструктор з параметрами																																					
        {
            if (size > 0 && size != this._size)
            {
                this._size = size;
                this._massyv = new int[this._size];
            }
        }

        public int SIZE	                        // властивість для поля size																																				
        {
            set
            {
                if (value > 0 && value != this._size)
                {
                    this._size = value;
                    this._massyv = new int[this._size];
                }
            }
            get { return this._size; }
        }

        public int this[int index]              // індексатор																																					
        {
            set
            {
                if (index >= 0 && index < this._size)
                {
                    this._massyv[index] = value;
                }
            }
            get
            {
                if (index >= 0 && index < this._size)
                {
                    return this._massyv[index];
                }
                return -1;
            }
        }

        public void Print()                         // метод - друк масиву																																					
        {
            foreach (var item in _massyv)
            {
                Console.Write($"{ item }\t");
            }
        }

        public int CountDistinct()	        // метод (реалізація інтерфейсу) - пошук кількості унікальних елементів масиву																																				
        {
            //Console.WriteLine("\n\n");																																					
            int count = 0;
            int i, j;
            for (i = 0; i < this._size; i++)
            {
                for (j = 0; j < this._size; j++)
                {
                    if (i == j)
                        continue;
                    else if (this._massyv[i] == this._massyv[j])
                        break;
                }
                if (j == this._size)
                {
                    count++;
                    //Console.Write($"{ this._massyv[i] }\t");																																					
                }
            }
            return count;
        }

        public int EqualToValue(int valueToCompare)      // метод (реалізація інтерфейсу) - пошук кількості чисел, що рівні заданому																																					
        {
            int count = 0;
            foreach (var item in _massyv)
            {
                if (item == valueToCompare)
                    count++;
            }
            return count;
        }
    }

    /*********************************************************************************************************************/
    internal class Program_3
    {

        //--------------------------------------------------------------------------------------------------------																																					
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_38 \"Task 3\"\n");

            MyArray myArray = new MyArray();
            Random rndmNumber = new Random();

            int index, size;

            do
            {
                do													// запит розміру масиву в об'єкті																								
                {
                    Console.Write("\nEnter the array size ( > 0 ): ");
                    size = Convert.ToInt32(Console.ReadLine());
                    if (size < 1)
                        Console.WriteLine("Incorrect! Try again\n");
                } while (size < 1);

                myArray.SIZE = size;

                for (int i = 0; i < myArray.SIZE; i++)				// цикл для заповнення масиву випаковими числами																																	
                {
                    myArray[i] = rndmNumber.Next(1, 101);
                }

                Console.WriteLine("\nArray:\n");				    // друк масиву																																	
                myArray.Print();

                Console.Write("\n\nCount unique numbers in the array: {0}", myArray.CountDistinct());   // підрахунок унікальних елементів масиву																																					

                Console.Write("\n\nEnter the your own number: ");   // введення власного числа для порівняння																																					
                index = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nCount numbers from array is equal to  your number: {0}", myArray.EqualToValue(index)); // кількість чисел, що рівні заданому																																					

                //--------------------------------------------------------------------------------------------------------																																					

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
