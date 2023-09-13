namespace Temperatures
{
    public class TemperaturesInMemory : TemperaturesBase
    {
        public override event TemperatureAddedDelegate TemperatureAdded;

        private List<float> temperatures = new List<float>();

        public TemperaturesInMemory(string measurementsPlace) 
            : base(measurementsPlace)
        {
        }

        public override void AddTemperature(float temperature)
        {
            if (temperature >= -50 && temperature <= 50) 
            {
                this.temperatures.Add(temperature);

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
            foreach(var temperature in this.temperatures)
            {
                statistics.AddTemperature(temperature);
            }
            return statistics;
        }

    }
}
