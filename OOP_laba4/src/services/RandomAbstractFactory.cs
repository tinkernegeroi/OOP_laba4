using OOP_laba4.classes;

namespace OOP_laba4.services;

/// <summary>
/// Конкретная реализация <see cref="AbstractFactory"/>, создающая объекты
/// с произвольными характеристиками на основе реальных российских аэропортов
/// и распространённых моделей самолётов.
/// Использует паттерн Flyweight через <see cref="AirplaneFlyweightFactory"/>
/// для разделения общих данных о моделях самолётов.
/// </summary>
public class RandomAbstractFactory : AbstractFactory
{
    /// <summary>
    /// Набор названий российских аэропортов для случайного выбора.
    /// </summary>
    private static readonly string[] Names =
        { "Шереметьево", "Домодедово", "Внуково", "Пулково", "Кольцово" };

    /// <summary>
    /// Набор городов России для случайного выбора местоположения.
    /// </summary>
    private static readonly string[] Locations =
        { "Москва", "Санкт-Петербург", "Екатеринбург", "Казань", "Новосибирск" };

    /// <summary>
    /// Набор популярных моделей самолётов для случайного выбора.
    /// </summary>
    private static readonly string[] AirplaneModels =
        { "Boeing 737", "Airbus A320", "Superjet 100" };

    /// <summary>
    /// Генератор случайных чисел для выбора параметров создаваемых объектов.
    /// </summary>
    private readonly Random _random = new Random();

    /// <summary>
    /// Общая фабрика легковесов, разделяемая всеми экземплярами <see cref="RandomAbstractFactory"/>.
    /// </summary>
    private static readonly AirplaneFlyweightFactory _flyweightFactory = new();

    /// <summary>
    /// Создаёт и возвращает новый объект <see cref="Airport"/> со случайными характеристиками
    /// в диапазонах, характерных для среднего аэропорта.
    /// </summary>
    /// <returns>Новый экземпляр <see cref="Airport"/> со случайными параметрами.</returns>
    public Airport CreateAirport()
    {
        return new Airport(
            name: Names[_random.Next(Names.Length)],
            location: Locations[_random.Next(Locations.Length)],
            flightsPerDay: _random.Next(10, 200),
            ticketsSold: _random.Next(100, 5000),
            balance: (decimal)(_random.NextDouble() * 1_000_000),
            rating: Math.Round(_random.NextDouble() * 5, 1),
            employeesCount: _random.Next(50, 2000)
        );
    }

    /// <summary>
    /// Создаёт и возвращает новый объект <see cref="Airplane"/> для случайно выбранной модели.
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