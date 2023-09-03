namespace Temperatures.Tests
{
    public class Tests
    {   
        [Test]
        public void WhenTemperaturesAdded_MinShouldReturnMinimalValue()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            temperatures.AddTemperature(-15);
            temperatures.AddTemperature(4);
            temperatures.AddTemperature(13);

            var statistics = temperatures.GetStatistics();

            Assert.AreEqual(-15, statistics.Min);
        }
        [Test]
        public void WhenTemperaturesAdded_MaxShouldReturnMaximalValue()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            temperatures.AddTemperature(-15);
            temperatures.AddTemperature(4);
            temperatures.AddTemperature(13);

            var statistics = temperatures.GetStatistics();

            Assert.AreEqual(13, statistics.Max);
        }
        [Test]
        public void WhenTemperaturesAdded_AverageShouldReturnAverageValue()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            temperatures.AddTemperature(-15);
            temperatures.AddTemperature(4);
            temperatures.AddTemperature(14);

            var statistics = temperatures.GetStatistics();

            Assert.AreEqual(1, statistics.Average);
        }
        [Test]
        public void WhenAddedG_ShouldReturn20Degrees()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            temperatures.AddTemperature('G');

            var statistics = temperatures.GetStatistics();

            Assert.AreEqual(20, statistics.Average);
        }
        [Test]
        public void WhenTemperaturesInFahrenheit_ShouldReturnCorrectValue()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            var celsiusToFahrenheit = temperatures.GetStatistics().TemperatureInFahrenheit(0);

            Assert.AreEqual(32f, celsiusToFahrenheit);
        }
        [Test]
        public void WhenTemperaturesInKelvin_ShouldReturnCorrectValue()
        {
            var temperatures = new TemperaturesInMemory("Warsaw");

            var celsiusToKelvin = temperatures.GetStatistics().TemperatureInKelvin(0);

            Assert.AreEqual(273.15f, celsiusToKelvin);
        }
    }
}