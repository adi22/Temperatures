namespace Temperatures
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Average 
        {
            get 
            {
                return Sum / Count;
            }
        }

        public float Sum { get; private set; }

        public float Count { get; private set; }

        public Statistics() 
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
        }

        public void AddTemperature(float temperature) 
        {
            this.Count++;
            this.Sum += temperature;
            this.Min = Math.Min(this.Min, temperature);
            this.Max = Math.Max(this.Max, temperature);
        }

        public float TemperatureInFahrenheit(float temperature) 
        {
            return (float)Math.Round((temperature * (9f / 5f) + 32f), 2);
        }

        public float TemperatureInKelvin(float temperature) 
        {
            return (float)Math.Round((temperature + 273.15f), 2);
        }

    }
}