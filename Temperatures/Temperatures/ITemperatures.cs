using static Temperatures.TemperaturesBase;

namespace Temperatures
{
    public interface ITemperatures
    {
        string MeasurementsPlace { get; }

        void AddTemperature(float temperature);

        void AddTemperature(int temperature);
        
        void AddTemperature(char temperature);

        void AddTemperature(string temperature);

        event TemperatureAddedDelegate TemperatureAdded;

        Statistics GetStatistics();

    }
}
