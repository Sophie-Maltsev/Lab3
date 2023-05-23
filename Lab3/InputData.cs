using System;

namespace Lab3
{
    public static class InputData
    {
        public static double ReadDouble()
        {
            string text = Console.ReadLine();
            double result;

            while (!double.TryParse(text.Replace('.', ','), out result))
            {
                Console.WriteLine("Невернный ввод числа с плавающей точкой. Попробуйте снова: ");
                text = Console.ReadLine();
            }

            return result;
        }
        public static int ReadInt32()
        {
            string text = Console.ReadLine();
            int result;

            while (!int.TryParse(text, out result))
            {
                Console.WriteLine("Невернный ввод целого числа. Попробуйте снова: ");
                text = Console.ReadLine();
            }

            return result;
        }
    }
}
