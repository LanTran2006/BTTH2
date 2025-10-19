using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Nhap thang (1-12): ");
        int month = int.Parse(Console.ReadLine()!);

        Console.Write("Nhap nam: ");
        int year = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nMonth: {month:D2}/{year}");
        Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");

        DateTime firstDay = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);
        int startDay = (int)firstDay.DayOfWeek; // Sunday = 0

        for (int i = 0; i < startDay; i++)
        {
            Console.Write("    ");
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,4}");
            if ((day + startDay) % 7 == 0)
                Console.WriteLine();
        }

        Console.WriteLine("\n");
    }
}
