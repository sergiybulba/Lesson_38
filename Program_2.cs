/* C#, lesson_38  01.04.2023																																														
																																														
Task № 2:																																														
Створіть інтерфейс IOutput2. У ньому мають бути два методи:																																														
¦ void ShowEven() — відображає парні значення контейнера з даними;																																														
¦ void ShowOdd() — відображає непарні значення контейнера з даними.																																														
Клас, створений раніше у практичному завданні Array, має імплементувати інтерфейс IOutput2.																																														
Метод ShowEven — відображає парні значення з масиву.																																														
Метод ShowOdd — відображає непарні значення масиву.																																														
Напишіть код для тестування отриманої функціональності. */
//--------------------------------------------------------------------------------------------------------																																														
using System;
using System.Globalization;

namespace Lesson_38
{
    //--------------------------------------------------------------------------------------------------------																																														

    interface IOutput2                             // інтерфейс																																														
    {
        void ShowEven();
        void ShowOdd();
    }

    //--------------------------------------------------------------------------------------------------------																																														
    class MyArray : IOutput2                      // оголошення класу																																														
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

        public void ShowEven()	        // метод (реалізація інтерфейсу) - друк всіх парних елементів																																													
        {
            int count = 0;
            foreach (var item in _massyv)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{ item }\t");
                    count++;
                }

            }
            if (count == 0)
            {
                Console.WriteLine("There are no even elements. ");
            }
        }

        public void ShowOdd()	        // метод (реалізація інтерфейсу) - друк всіх непарних елементів																																													
        {
            int count = 0;
            foreach (var item in _massyv)
            {
                if (item % 2 == 1)
                {
                    Console.Write($"{ item }\t");
                    count++;
                }

            }
            if (count == 0)
            {
                Console.WriteLine("There are no odd elements. ");
            }
        }
    }

    /*********************************************************************************************************************/
    internal class Program_2
    {
        //--------------------------------------------------------------------------------------------------------																																														
        static void Main(string[] args)
        {
            Console.WriteLine("Program \"C# lesson_38 \"Task 2\"\n");

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

                Console.WriteLine("\n\nEven elements: \n");         // вивести в консоль всі парні елементи																																														
                myArray.ShowEven();
                Console.WriteLine("\n\nOdd elements: \n");          // вивести в консоль всі непарні елементи																																														
                myArray.ShowOdd();

                //--------------------------------------------------------------------------------------------------------																																														

                // продовжити ?																																														
                Console.Write("\n\nDo you want to continue? ('1' for 'yes'): ");
                index = Convert.ToInt32(Console.ReadLine());

            } while (index == 1);


            Console.WriteLine("\n\nThe program is over ...\n\n");
        }
    }
}
