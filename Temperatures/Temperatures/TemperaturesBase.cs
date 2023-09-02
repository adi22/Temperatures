namespace Temperatures
{
    public abstract class TemperaturesBase : ITemperatures
    {
        public delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        public abstract event TemperatureAddedDelegate TemperatureAdded;
        public TemperaturesBase(string measurementsPlace)
        {
            this.MeasurementsPlace = measurementsPlace;
        }
        public string MeasurementsPlace { get; private set; }
        
        public abstract void AddTemperature(float temperature);

        public void AddTemperature(int temperature)
        {
            var result = (float)temperature;
            this.AddTemperature(result);
        }

        public void AddTemperature(string temperature)
        {
            if(float.TryParse(temperature, out float result))
            {
                this.AddTemperature(result);
            }
            else
            {
                throw new Exception("String is not a float");
            }
        }

        public void AddTemperature(char temperature)
        {
            switch (temperature)
            {
                case 'A':
                case 'a':
                    this.AddTemperature(-40);
                    break;
                case 'B':
                case 'b':
                    this.AddTemperature(-30);
                    break;
                case 'C':
                case 'c':
                    this.AddTemperature(-20);
                    break;
                case 'D':
                case 'd':
                    this.AddTemperature(-10);
                    break;
                case 'E':
                case 'e':
                    this.AddTemperature(0);
                    break;
                case 'F':
                case 'f':
                    this.AddTemperature(10);
                    break;
                case 'G':
                case 'g':
                    this.AddTemperature(20);
                    break;
                case 'H':
                case 'h':
                    this.AddTemperature(30);
                    break;
                case 'I':
                case 'i':
                    this.AddTemperature(40);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }

        public abstract Statistics GetStatistics();
        
    }
}
