namespace Temperatures
{
    public class TemperaturesInFile : TemperaturesBase
    {
        public override event TemperatureAddedDelegate TemperatureAdded;

        private const string fileName = "temperatures.txt";
        public TemperaturesInFile(string measurementsPlace) 
            : base(measurementsPlace)
        {
        }

        public override void AddTemperature(float temperature)
        {
            if (temperature >= -50 && temperature <= 50)
            {
                using (var writer = File.AppendText(fileName)) 
                {
                    writer.WriteLine(temperature);
                }

                if (TemperatureAdded != null)
                {
                    TemperatureAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid temperature value");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName)) 
                {
                    var line = reader.ReadLine();

                    while(line != null) 
                    {
                        if (float.TryParse(line, out float result))
                        {
                            statistics.AddTemperature(result);

                            line = reader.ReadLine();
                        }
                        else
                        {
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            return statistics;
        }
    }
}
