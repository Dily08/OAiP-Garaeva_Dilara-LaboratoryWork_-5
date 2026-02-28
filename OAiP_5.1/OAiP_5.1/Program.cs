using System;

namespace GeometricProgressionTask
{
    class GeometricProgression
    {
        public double first;
        public double second;
        public GeometricProgression(double a0, double r)
        {
            first = a0;
            second = r;
        }

        public double ElementJ(int j)
        {
            return first * Math.Pow(second, j);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление элемента геометрической прогрессии");
            Console.WriteLine("Формула: a_j = a0 * r^j");
            try
            {
                Console.Write("Введите первый элемент прогрессии (a0): ");
                double a0 = double.Parse(Console.ReadLine().Replace(',', '.'));

                Console.Write("Введите знаменатель прогрессии (r): ");
                double r = double.Parse(Console.ReadLine().Replace(',', '.'));

                GeometricProgression progression = new GeometricProgression(a0, r);


                Console.Write("Введите номер элемента, который нужно найти (j): ");
                int j = int.Parse(Console.ReadLine());


                double result = progression.ElementJ(j);

                Console.WriteLine($"Элемент прогрессии с номером {j} равен: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректные числовые значения.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}