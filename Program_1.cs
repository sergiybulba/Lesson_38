/* C#, lesson_38  01.04.2023																																					
																																					
Task № 1:																																					
Створіть інтерфейс ICalc. У ньому мають бути два методи:																																					
¦ int Less(int valueToCompare) — повертає кількість менших значень, ніж valueToCompare;																																					
¦ int Greater(intvalueToCompare) — повертає кількість більших значень, ніж valueToCompare.																																					
Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс ICalc.																																					
Метод Less — повертає кількість елементів масиву менших, ніж valueToCompare.																																					
Метод Greater — повертає кількість елементів масиву більших, ніж valueToCompare.																																					
Напишіть код для тестування отриманої функціональності. */
//--------------------------------------------------------------------------------------------------------																																					
using System;
using System.Globalization;

namespace Lesson_38
{
    //--------------------------------------------------------------------------------------------------------																																					

    interface ICalc                             // інтерфейс																																					
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }

    //--------------------------------------------------------------------------------------------------------																																					
    class MyArray : ICalc                      // оголошення класу																																					
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

        public int Less(int valueToCompare)	        // метод (реалізація інтерфейсу) - пошук кількості чисел менше заданого																																				
        {
            int count = 0;
            foreach (var item in _massyv)
            {
                if (item < valueToCompare)
                    count++;
            }
            return count;
        }

        public int Greater(int valueToCompare)      // метод (реалізація інтерфейсу) - пошук кількості чисел більше заданого																																					
        {
            int count = 0;
            foreach (var item in _massyv)
            {
                if (item > valueToCompare)
                    count++;
            }
            return count;
        }
    }

    /*********************************************************************************************************************/
    internal class Program_1
    {

        //--------------------------------------------------------------------------------------------------------																																					
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_38 \"Task 1\"\n");

            MyArray myArray = new MyArray();            // оголошення об'єкта																																					
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

                Console.Write("\n\nEnter the your own number: ");   // введення власного числа для порівняння																																					
                index = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nCount numbers from array less    than your number: {0}", myArray.Less(index));		// кількість чисел менше заданого																																			
                Console.Write("\nCount numbers from array greater than your number: {0}", myArray.Greater(index));  // кількість чисел більше заданого																																					

                //--------------------------------------------------------------------------------------------------------																																					

                // продовжити ?																																					
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
