namespace Assignement1;

public class Practice_loops_and_operators
{
    public void q1()
    {
        Console.WriteLine("Part 1");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
        
        Console.WriteLine("Part 2");
        Console.WriteLine("When the given code executes, it will result in an infinite loop because the byte type has a maximum value of 255. When i exceeds 255, it wraps around to 0 due to overflow, making the condition i < max always true.");
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
            if (i == 255)
            {
                Console.WriteLine("Warning: Byte overflow will occur after this value!");
                break; // To prevent infinite loop, you can break here for demonstration
            }
        }
        Console.WriteLine("End of loop");
    }

    public void q2()
    {
        int n;
        Console.WriteLine("Enter the number of rows for the pyramid:");
        
        if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            return;
        }
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public void q3()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number between 1 and 3:");
        
        int guessedNumber;
        if (int.TryParse(Console.ReadLine(), out guessedNumber))
        {
            if (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.WriteLine("Your guess is outside the valid range (1 to 3).");
            }
            else
            {
                if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else if (guessedNumber > correctNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public void q4()
    {
        // Define the birth date of the person
        DateTime birthDate = new DateTime(2000, 1, 1);
        TimeSpan age = DateTime.Today - birthDate;
        int daysOld = (int)age.TotalDays;
        Console.WriteLine($"You are {daysOld} days old.");

        // Calculate days until the next 10,000 day anniversary
        int daysToNextAnniversary = 10000 - (daysOld % 10000);
        DateTime nextAnniversaryDate = DateTime.Today.AddDays(daysToNextAnniversary);
        Console.WriteLine($"Your next 10,000 day anniversary will be on: {nextAnniversaryDate:d}");
    }

    public void q5()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;
        
        if (hour >= 7 && hour < 12)
        {
            Console.WriteLine("Good Morning");
        }
        if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }
        if (hour >= 17 && hour < 22)
        {
            Console.WriteLine("Good Evening");
        }
        if (hour >= 22 || hour < 7)
        {
            Console.WriteLine("Good Night");
        }
    }

    public void q6()
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            for (int i = 0; i <= 24; i += increment)
            {
                Console.Write(i);
                if (i < 24)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }
    }
}