namespace OOP_laba4.classes;

public class AirplaneFlyweight
{
    public string Model { get; }
    public int Capacity { get; }
    public double RangeKm { get; }
    
    public AirplaneFlyweight(string model, int capacity, double rangeKm)
    {
        Model = model;
        Capacity = capacity;
        RangeKm = rangeKm;
    }
    
    public string GetInfo(string flightNumber, string destination)
    {
        return $"Самолет: {Model}, Вместимость: {Capacity}, " +
               $"Дальность: {RangeKm} км | " +
               $"Рейс: {flightNumber} → {destination}";
    }
}