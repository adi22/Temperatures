using Temperatures;
void TemperatureAdded(object sender, EventArgs args)
{
    Console.WriteLine("New temperature measurement added");
}

var temperaturesInMemory = new TemperaturesInMemory("Warsaw");
temperaturesInMemory.TemperatureAdded += TemperatureAdded;

var temperaturesInFile = new TemperaturesInFile("Warsaw");
temperaturesInFile.TemperatureAdded += TemperatureAdded;


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
            while (true)
            {              
                Console.WriteLine("Add temperature: ");
                input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                if (input.Length == 1 && !(int.TryParse(input, out int intResult)))
                {
                    try
                    {
                        char.TryParse(input, out char result);
                        temperaturesInMemory.AddTemperature(result);
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
                        temperaturesInMemory.AddTemperature(input);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception catched: {e.Message}");
                    }
                }
                
            }
            Console.WriteLine("Show statistics in:");
            Console.WriteLine("'1' Celsius degrees");
            Console.WriteLine("'2' Fahrenheit degrees");
            Console.WriteLine("'3' Kelvins");
            Console.WriteLine();

            var statisticsFromMemory = temperaturesInMemory.GetStatistics();

            input = Console.ReadLine();
            switch(input)
            { 
                case "1":
                    Console.WriteLine($"Min: {statisticsFromMemory.Min}");
                    Console.WriteLine($"Max: {statisticsFromMemory.Max}");
                    Console.WriteLine($"Average: {Math.Round(statisticsFromMemory.Average, 2)}");
                    break;
                case "2":
                    Console.WriteLine($"Min: {statisticsFromMemory.TemperatureInFahrenheit(statisticsFromMemory.Min)}");
                    Console.WriteLine($"Max: {statisticsFromMemory.TemperatureInFahrenheit(statisticsFromMemory.Max)}");
                    Console.WriteLine($"Average: {statisticsFromMemory.TemperatureInFahrenheit(statisticsFromMemory.Average)}");
                    break;
                case "3":
                    Console.WriteLine($"Min: {statisticsFromMemory.TemperatureInKelvin(statisticsFromMemory.Min)}");
                    Console.WriteLine($"Max: {statisticsFromMemory.TemperatureInKelvin(statisticsFromMemory.Max)}");
                    Console.WriteLine($"Average: {statisticsFromMemory.TemperatureInKelvin(statisticsFromMemory.Average)}");
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
            break;

        case "2":
            while (true)
            {
                Console.WriteLine("Add temperature: ");
                input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                if (input.Length == 1 && !(int.TryParse(input, out int intResult)))
                {
                    try
                    {
                        char.TryParse(input, out char result);
                        temperaturesInFile.AddTemperature(result);
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
                        temperaturesInFile.AddTemperature(input);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception catched: {e.Message}");
                    }
                }

            }
            Console.WriteLine("Show statistics in:");
            Console.WriteLine("'1' Celsius degrees");
            Console.WriteLine("'2' Fahrenheit degrees");
            Console.WriteLine("'3' Kelvins");
            Console.WriteLine();

            var statisticsFromFile = temperaturesInFile.GetStatistics();

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine($"Min: {statisticsFromFile.Min}");
                    Console.WriteLine($"Max: {statisticsFromFile.Max}");
                    Console.WriteLine($"Average: {Math.Round(statisticsFromFile.Average, 2)}");
                    break;
                case "2":
                    Console.WriteLine($"Min: {statisticsFromFile.TemperatureInFahrenheit(statisticsFromFile.Min)}");
                    Console.WriteLine($"Max: {statisticsFromFile.TemperatureInFahrenheit(statisticsFromFile.Max)}");
                    Console.WriteLine($"Average: {statisticsFromFile.TemperatureInFahrenheit(statisticsFromFile.Average)}");
                    break;
                case "3":
                    Console.WriteLine($"Min: {statisticsFromFile.TemperatureInKelvin(statisticsFromFile.Min)}");
                    Console.WriteLine($"Max: {statisticsFromFile.TemperatureInKelvin(statisticsFromFile.Max)}");
                    Console.WriteLine($"Average: {statisticsFromFile.TemperatureInKelvin(statisticsFromFile.Average)}");
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
            break;
        default:
            Console.WriteLine("Select correct option from menu!");
            break;
    }
}