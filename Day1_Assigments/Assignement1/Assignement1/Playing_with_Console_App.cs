namespace Assignement1;

public class Playing_with_Console_App
{
    public void q1()
    {
        Console.WriteLine("Type: sbyte");
        Console.WriteLine($"Size: {sizeof(sbyte)} bytes");
        Console.WriteLine($"Min Value: {sbyte.MinValue}");
        Console.WriteLine($"Max Value: {sbyte.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: byte");
        Console.WriteLine($"Size: {sizeof(byte)} bytes");
        Console.WriteLine($"Min Value: {byte.MinValue}");
        Console.WriteLine($"Max Value: {byte.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: short");
        Console.WriteLine($"Size: {sizeof(short)} bytes");
        Console.WriteLine($"Min Value: {short.MinValue}");
        Console.WriteLine($"Max Value: {short.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: ushort");
        Console.WriteLine($"Size: {sizeof(ushort)} bytes");
        Console.WriteLine($"Min Value: {ushort.MinValue}");
        Console.WriteLine($"Max Value: {ushort.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: int");
        Console.WriteLine($"Size: {sizeof(int)} bytes");
        Console.WriteLine($"Min Value: {int.MinValue}");
        Console.WriteLine($"Max Value: {int.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: uint");
        Console.WriteLine($"Size: {sizeof(uint)} bytes");
        Console.WriteLine($"Min Value: {uint.MinValue}");
        Console.WriteLine($"Max Value: {uint.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: long");
        Console.WriteLine($"Size: {sizeof(long)} bytes");
        Console.WriteLine($"Min Value: {long.MinValue}");
        Console.WriteLine($"Max Value: {long.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: ulong");
        Console.WriteLine($"Size: {sizeof(ulong)} bytes");
        Console.WriteLine($"Min Value: {ulong.MinValue}");
        Console.WriteLine($"Max Value: {ulong.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: float");
        Console.WriteLine($"Size: {sizeof(float)} bytes");
        Console.WriteLine($"Min Value: {float.MinValue}");
        Console.WriteLine($"Max Value: {float.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: double");
        Console.WriteLine($"Size: {sizeof(double)} bytes");
        Console.WriteLine($"Min Value: {double.MinValue}");
        Console.WriteLine($"Max Value: {double.MaxValue}");
        Console.WriteLine();

        Console.WriteLine("Type: decimal");
        Console.WriteLine($"Size: {sizeof(decimal)} bytes");
        Console.WriteLine($"Min Value: {decimal.MinValue}");
        Console.WriteLine($"Max Value: {decimal.MaxValue}");
        Console.WriteLine();
    }

    public void q2()
    {
        Console.Write("Enter number of centuries: ");
        int input;
        if (int.TryParse(Console.ReadLine(), out input)) 
        {
            int YearsInCentury = 100;
            int DaysInYear = 36524; 
            int HoursInDay = 24;
            int MinutesInHour = 60;
            int SecondsInMinute = 60;
            int MillisecondsInSecond = 1000;
            int MicrosecondsInMillisecond = 1000;
            int NanosecondsInMicrosecond = 1000;
                
            long years = input * YearsInCentury;
            long days = (years * DaysInYear) / 100;
            long hours = days * HoursInDay;
            long minutes = hours * MinutesInHour;
            long seconds = minutes * SecondsInMinute;
            long milliseconds = seconds * MillisecondsInSecond;
            long microseconds = milliseconds * MicrosecondsInMillisecond;
            long nanoseconds = microseconds * NanosecondsInMicrosecond;

            // Displaying results
            Console.WriteLine($"{input} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer number.");
        }
    }

}