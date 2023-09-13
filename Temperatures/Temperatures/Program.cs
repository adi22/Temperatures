using Temperatures;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "q")
            {
                break;
            }
            switch (input)
            {
                case "1":
                    AddTemperatureToMemory();
                    break;

                case "2":
                    AddTemperatureToFile();
                    break;
                default:
                    Console.WriteLine("Select proper option from menu!");
                    break;
            }
        }
    }

    private static void TemperatureAdded(object sender, EventArgs args)
    {
        Console.WriteLine("New temperature measurement added");
    }

    private static void AddTemperatureToMemory()
    {
        var temperaturesInMemory = new TemperaturesInMemory("Warsaw");
        temperaturesInMemory.TemperatureAdded += TemperatureAdded;
        AddTemperature(temperaturesInMemory);
        ShowStatistics(temperaturesInMemory);
    }

    private static void AddTemperatureToFile()
    {
        var temperaturesInFile = new TemperaturesInFile("Warsaw");
        temperaturesInFile.TemperatureAdded += TemperatureAdded;
        AddTemperature(temperaturesInFile);
        ShowStatistics(temperaturesInFile);
    }

    private static void AddTemperature(ITemperatures temperature)
    {
        while (true)
        {
            Console.WriteLine("Add temperature: ");
            var input = Console.ReadLine();

            if (input == "q")
            {
                break;
            }
            if (input.Length == 1 && !(int.TryParse(input, out int intResult)))
            {
                try
                {
                    char.TryParse(input, out char result);
                    temperature.AddTemperature(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
            }
            else
            {
                try
                {
                    temperature.AddTemperature(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
            }

        }
    }

    private static void ShowStatistics(ITemperatures temperatures)
    {
        var statistics = temperatures.GetStatistics();

        Console.WriteLine("Show statistics in:");
        Console.WriteLine("'1' Celsius degrees");
        Console.WriteLine("'2' Fahrenheit degrees");
        Console.WriteLine("'3' Kelvins");
        Console.WriteLine("Or enter 'q' to back to the main menu");

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "q")
            {
                Menu();
                break;
            }
            switch (input)
            {
                case "1":
                    Console.WriteLine($"Min: {statistics.Min}");
                    Console.WriteLine($"Max: {statistics.Max}");
                    Console.WriteLine($"Average: {Math.Round(statistics.Average, 2)}");
                    break;
                case "2":
                    Console.WriteLine($"Min: {statistics.TemperatureInFahrenheit(statistics.Min)}");
                    Console.WriteLine($"Max: {statistics.TemperatureInFahrenheit(statistics.Max)}");
                    Console.WriteLine($"Average: {statistics.TemperatureInFahrenheit(statistics.Average)}");
                    break;
                case "3":
                    Console.WriteLine($"Min: {statistics.TemperatureInKelvin(statistics.Min)}");
                    Console.WriteLine($"Max: {statistics.TemperatureInKelvin(statistics.Max)}");
                    Console.WriteLine($"Average: {statistics.TemperatureInKelvin(statistics.Average)}");
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }

    private static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("=============================================================================");
        Console.WriteLine("Hello in application to calculating statistics of entered temperatures.");
        Console.WriteLine("Add temperatures in Celsius degrees");
        Console.WriteLine("=============================================================================");
        Console.WriteLine("Select the option from the menu below:");
        Console.WriteLine("Enter '1' to add temperatures and calculate statistics without saving to file");
        Console.WriteLine("Enter '2' to add temperatures and calculate statistics from file");
        Console.WriteLine("Enter 'q' to quit application or stop entering temperatures");
        Console.WriteLine("=============================================================================");
        Console.WriteLine();
    }
}
