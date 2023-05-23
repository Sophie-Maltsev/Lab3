using System;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Vector vector1 = new Vector(4, 5, 6);
            Vector vector2 = new Vector(5); 

            Console.WriteLine(vector1.ToString());
            Console.WriteLine("\n\nМодуль: " + vector1.GetModule());
            Console.WriteLine("Максимальный элемент: " + vector1.GetMaxElement());
            Console.WriteLine("Индекс минимального элемента: " + vector1.GetIndexMinElement());

            Console.WriteLine("\n\n" + vector2.ToString());
            vector2 = vector2.GetPositiveVector();
            Console.WriteLine("Его положительный вектор: " + vector2.ToString());

            Console.WriteLine("\n\nСумма 2 векторов выше: " + Vector.Sum(vector1, vector2).ToString());
            Console.WriteLine("Скалярное произведение: " + Vector.ScalarComposition(vector1, vector2));

            Vector vector3 = new Vector(vector1);

            Console.WriteLine("Вектор 1 равен вектору 2 ? - " + Vector.Equals(vector1, vector2));
            Console.WriteLine("Вектор 1 равен вектору 3 ? - " + Vector.Equals(vector1, vector3));
        }
    }

    class Vector
    {
        private double[] Numbers { get; set; }
        public int Length { get => Numbers.Length; }


        /// <summary>
        /// Конструктор с параметром, принимает размер вектора и позволяет задать этот вектор с консоли.
        /// </summary>
        /// <param name="n">Размер вектора</param>
        public Vector(int n)
        {
            Numbers = new double[n];
            SetVectorNumbers();
        }
        /// <summary>
        /// Конструктор с параметром, принимает массив double-чисел. (params - позволяет указать числа через запятую,
        /// без создания массива).
        /// </summary>
        /// <param name="numbers"></param>
        public Vector(params double[] numbers)
        {
            Numbers = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
                Numbers[i] = numbers[i];
        }
        /// <summary>
        /// Копирующий конструктор, он копирует уже созданный вектор и возвращает его копию.
        /// </summary>
        /// <param name="vector"></param>
        public Vector(Vector vector)
        {
            Numbers = vector.Numbers;

            Numbers = new double[vector.Length];

            for (int i = 0; i < Numbers.Length; i++)
                Numbers[i] = vector.Numbers[i];
        }


        /// <summary>
        /// Позволяет заполнить массив числами.
        /// </summary>
        public void SetVectorNumbers()
        {
            Console.WriteLine("Необходимо заполнить элементы вектора: ");

            for (int i = 0; i < Length; i++)
            {  
                Console.Write("Введите число №" + (i + 1) + ": ");
                Numbers[i] = InputData.ReadDouble();
            }
        }

        /// <summary>
        /// Возвращающая модуль вектора
        /// </summary>
        /// <returns></returns>
        public double GetModule()
        {
            double result = 0;

            for (int i = 0; i < Length; i++)
            {
                result += Numbers[i] * Numbers[i];
                //result += Math.Pow(Numbers[i], 2);
            }

            return Math.Sqrt(result);
        }

        /// <summary>
        /// Возвращает наибольший элемент вектора
        /// </summary>
        /// <returns></returns>
        public double GetMaxElement()
        {
            double max = Numbers[0];

            for (int i = 1; i < Length; i++)
            {
                if (max < Numbers[i])
                    max = Numbers[i];
            }

            return max;
            //return Numbers.Max();
        }

        /// <summary>
        /// Возвращает индекс наименьшего элемента вектора
        /// </summary>
        /// <returns></returns>
        public int GetIndexMinElement()
        {
            double min = Numbers[0];
            int index = 0;

            for (int i = 1; i < Length; i++)
            {
                if (min > Numbers[i])
                {
                    min = Numbers[i];
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Возвращает положительные элементы вектора
        /// </summary>
        /// <returns></returns>
        public Vector GetPositiveVector()
        {
            int count = 0;

            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] > 0)
                    count++;
            }

            int index = 0;
            double[] massiv = new double[count];

            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] > 0)
                {
                    massiv[index] = Numbers[i];
                    index++;
                }
            }

            return new Vector(massiv);
            //return new Vector(Numbers.Where(x => x > 0).ToArray());
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string vector = "vector[" + Length + "]: ";

            for (int i = 0; i < Numbers.Length; i++)
                vector += Numbers[i] + ", ";

            vector = vector.Remove(vector.Length - 2, 2);
            return vector;
        }

        /// <summary>
        /// Возвращает сумму векторов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Vector Sum(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
                throw new Exception("Длины векторов не соответствуют друг другу.");

            double[] massiv = new double[v1.Length];

            for (int i = 0; i < v1.Length; i++)
                massiv[i] = v1.Numbers[i] + v2.Numbers[i];

            return new Vector(massiv);
        }

        /// <summary>
        /// Возвращает скалярное произведение
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double ScalarComposition(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
                throw new Exception("Длины векторов не соответствуют друг другу.");

            double composition = 0;

            for (int i = 0; i < v1.Length; i++)
                composition += v1.Numbers[i] * v2.Numbers[i];

            return composition;
        }

        /// <summary>
        /// Проверяет векторы на равенство
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>true - векторы равны / false - не равны</returns>
        public static bool Equals(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
                return false;

            for (int i = 0; i < v1.Length; i++)
            {
                if (v1.Numbers[i] != v2.Numbers[i])
                    return false;
            }

            return true;
        }
    }
}