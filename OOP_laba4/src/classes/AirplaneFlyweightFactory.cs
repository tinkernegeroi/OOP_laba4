namespace OOP_laba4.classes;

/// <summary>
/// Фабрика легковесов (Flyweight Factory) для объектов <see cref="AirplaneFlyweight"/>.
/// Кэширует созданные экземпляры, гарантируя, что для каждой модели самолёта
/// существует только один разделяемый объект-легковес.
/// </summary>
public class AirplaneFlyweightFactory
{
    /// <summary>
    /// Внутренний кэш легковесов, ключ — модель самолёта.
    /// </summary>
    private readonly Dictionary<string, AirplaneFlyweight> _cache = new();

    private readonly Random _random = new Random();

    /// <summary>
    /// Предопределённые характеристики известных моделей самолётов.
    /// </summary>
    private static readonly (string Model, int Capacity, double Range)[] _specs =
    {
        ("Boeing 737",   150, 5000),
        ("Airbus A320",  180, 6000),
        ("Superjet 100", 100, 3000),
    };

    /// <summary>
    /// Возвращает легковес для указанной модели самолёта.
    /// Если легковес с такой моделью уже существует в кэше — возвращает его,
    /// иначе создаёт новый, сохраняет в кэше и возвращает.
    /// </summary>
    /// <param name="model">Название модели самолёта.</param>
    /// <returns>Общий объект <see cref="AirplaneFlyweight"/> для данной модели.</returns>
    public AirplaneFlyweight GetFlyweight(string model)
    {
        if (!_cache.TryGetValue(model, out var flyweight))
        {
            var spec = _specs.FirstOrDefault(s => s.Model == model);

            flyweight = spec != default
                ? new AirplaneFlyweight(spec.Model, spec.Capacity, spec.Range)
                : new AirplaneFlyweight(model, _random.Next(10, 200), _random.Next(1000, 7000));

            _cache[model] = flyweight;
        }

        return flyweight;
    }

    /// <summary>
    /// Количество уникальных легковесов, хранящихся в кэше на данный момент.
    /// </summary>
    public int CacheSize => _cache.Count;
}