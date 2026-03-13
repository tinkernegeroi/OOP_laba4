using OOP_laba4.classes;

namespace OOP_laba4.services;

/// <summary>
/// Конкретная реализация <see cref="AbstractFactory"/>, создающая объекты
/// премиум-класса: элитные аэропорты и самолёты бизнес-авиации.
/// Использует паттерн Flyweight через <see cref="AirplaneFlyweightFactory"/>
/// для разделения общих характеристик моделей самолётов.
/// </summary>
public class PremiumAbstractFactory : AbstractFactory
{
    /// <summary>
    /// Набор названий премиум-аэропортов для случайного выбора.
    /// </summary>
    private static readonly string[] AirportNames =
        { "VIP International", "Elite Sky Hub", "Royal AirPort", "Platinum Wings" };

    /// <summary>
    /// Набор престижных городов для случайного выбора местоположения.
    /// </summary>
    private static readonly string[] Locations =
        { "Дубай", "Сингапур", "Монако", "Цюрих" };

    /// <summary>
    /// Набор моделей самолётов бизнес- и премиум-класса.
    /// </summary>
    private static readonly string[] AirplaneModels =
        { "Boeing 787", "Airbus A350", "Gulfstream G700", "Bombardier Global 8000" };

    /// <summary>
    /// Генератор случайных чисел для выбора параметров создаваемых объектов.
    /// </summary>
    private readonly Random _random = new Random();

    /// <summary>
    /// Общая фабрика легковесов, разделяемая всеми экземплярами <see cref="PremiumAbstractFactory"/>.
    /// </summary>
    private static readonly AirplaneFlyweightFactory _flyweightFactory = new AirplaneFlyweightFactory();

    /// <summary>
    /// Создаёт и возвращает новый объект <see cref="Airport"/> с характеристиками
    /// премиум-класса: высокий трафик, большой баланс, рейтинг от 4.5 до 5.0.
    /// </summary>
    /// <returns>Новый экземпляр <see cref="Airport"/> премиум-уровня.</returns>
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

    /// <summary>
    /// Создаёт и возвращает новый объект <see cref="Airplane"/> для премиум-модели.
    /// Легковес для выбранной модели берётся из общего кэша <see cref="_flyweightFactory"/>.
    /// </summary>
    /// <returns>Новый экземпляр <see cref="Airplane"/> с случайным рейсом и пунктом назначения.</returns>
    public Airplane CreateAirplane()
    {
        var model = AirplaneModels[_random.Next(AirplaneModels.Length)];
        var flyweight = _flyweightFactory.GetFlyweight(model);

        var flightNumber = $"SU-{_random.Next(100, 999)}";
        var destination = Locations[_random.Next(Locations.Length)];

        return new Airplane(flyweight, flightNumber, destination);
    }

    /// <summary>
    /// Количество уникальных моделей самолётов, закэшированных фабрикой легковесов
    /// для данного типа фабрики.
    /// </summary>
    public static int FlyweightCacheSize => _flyweightFactory.CacheSize;
}