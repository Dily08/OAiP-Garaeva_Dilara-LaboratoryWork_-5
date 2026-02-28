using System;

namespace ConsoleApp1
{
    internal class Koord
    {
        private int degrees; // градусы
        private float minutes; // минуты
        private char direction; // направление
        const double KM_DEGREE = 111.0; // приближённое значение

        public Koord(int d = 0, float m = 0, char dir = 'N')
        {
            degrees = d;
            minutes = m;
            direction = char.ToUpper(dir);
        }

        public void Read()
        {
            Console.Write("degrees = ");
            degrees = int.Parse(Console.ReadLine());

            Console.Write("minutes = ");
            minutes = float.Parse(Console.ReadLine());

            Console.Write("direction (N/S/E/W) = ");
            direction = char.ToUpper(char.Parse(Console.ReadLine()));
        }

        public void Display()
        {
            Console.WriteLine($"{degrees}° {minutes}' {direction}");
        }

        public string GetHemisphere()
        {
            return direction switch
            {
                'N' => "Северное полушарие",
                'S' => "Южное полушарие",
                'W' => "Западное полушарие",
                'E' => "Восточное полушарие",
                _ => "Неизвестно"
            };
        }

        public double ToDecimal()
        {
            double dec = degrees + minutes / 60.0;
            return (direction == 'S' || direction == 'W') ? -dec : dec;
        }

        // lat - широта, lon - долгота
        public static double Distance(Koord lat1, Koord lon1, Koord lat2, Koord lon2)
        {
            double dLat = (lat2.ToDecimal() - lat1.ToDecimal()) * KM_DEGREE;
            double avgLat = ((lat1.ToDecimal() + lat2.ToDecimal()) / 2) * Math.PI / 180.0;
            double dLon = (lon2.ToDecimal() - lon1.ToDecimal()) * KM_DEGREE * Math.Cos(avgLat);

            return Math.Sqrt(dLat * dLat + dLon * dLon);
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Морская навигация");

            Koord lat1 = new Koord(59, 57, 'N');  // широта Питера
            Koord lon1 = new Koord(30, 19, 'E');  // долгота Питера

            Console.WriteLine("Точка 1 (Питер):");
            lat1.Display();
            lon1.Display();

            Console.WriteLine("\nВведите координаты второй точки:");
            Koord lat2 = new Koord();
            Koord lon2 = new Koord();

            Console.WriteLine("Широта:");
            lat2.Read();

            Console.WriteLine("Долгота:");
            lon2.Read();

            double dist = Koord.Distance(lat1, lon1, lat2, lon2);
            dist = Math.Round(dist, 2);

            Console.WriteLine($"\nРасстояние = {dist} км");
        }
    }
}