namespace OOP_laba4.classes;

public class AirplaneFlyweightFactory
{
    private readonly Dictionary<string, AirplaneFlyweight> _cache = new();
    
    private readonly Random _random = new Random();
    
    private static readonly (string Model, int Capacity, double Range)[] _specs =
    {
        ("Boeing 737",   150, 5000),
        ("Airbus A320",  180, 6000),
        ("Superjet 100", 100, 3000),
    };

    public AirplaneFlyweight GetFlyweight(string model)
    {
        if (!_cache.TryGetValue(model, out var flyweight))
        {
            var spec = _specs.FirstOrDefault(s => s.Model == model);
            
            flyweight = spec != default ? new AirplaneFlyweight(spec.Model, spec.Capacity, spec.Range)
                : new AirplaneFlyweight(model, _random.Next(10, 200), _random.Next(1000, 7000));
            
            _cache[model] = flyweight;
        }
        
        return flyweight;
    }
    
    public int CacheSize => _cache.Count;
}