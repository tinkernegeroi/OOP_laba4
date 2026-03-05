using OOP_laba4.classes;

namespace OOP_laba4.services;

public class PremiumAbstractFactory : AbstractFactory
{
    private static readonly string[] AirportNames =
        { "VIP International", "Elite Sky Hub", "Royal AirPort", "Platinum Wings" };

    private static readonly string[] Locations =
        { "Дубай", "Сингапур", "Монако", "Цюрих" };

    private static readonly string[] AirplaneModels =
        { "Boeing 787", "Airbus A350", "Gulfstream G700", "Bombardier Global 8000" };

    private readonly Random _random = new Random();
    
    private static readonly AirplaneFlyweightFactory _flyweightFactory =  new AirplaneFlyweightFactory();

    public Airport CreateAirport()
    {
        return new Airport(
            name: AirportNames[_random.Next(AirportNames.Length)],
            location: Locations[_random.Next(Locations.Length)],
            flightsPerDay: _random.Next(300, 800),
            ticketsSold: _random.Next(5000, 20000),
            balance: (decimal)(_random.NextDouble() * 100_000_000 + 10_000_000),
            rating: Math.Round(4.5 + _random.NextDouble() * 0.5, 1),
            employeesCount: _random.Next(2000, 10000)
        );
    }
    
    public Airplane CreateAirplane()
    {
        var model = AirplaneModels[_random.Next(AirplaneModels.Length)];
        var flyweight = _flyweightFactory.GetFlyweight(model);

        var flightNumber = $"SU-{_random.Next(100, 999)}";
        var destination = Locations[_random.Next(Locations.Length)];

        return new Airplane(flyweight, flightNumber, destination);
    }
    
    public static int FlyweightCacheSize => _flyweightFactory.CacheSize;
}