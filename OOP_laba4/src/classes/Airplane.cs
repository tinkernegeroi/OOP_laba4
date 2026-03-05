namespace OOP_laba4.classes;

public class Airplane
{
    private readonly AirplaneFlyweight _flyweight;
    
    public string FlightNumber { get; }
    public string Destination { get; }

    public Airplane(AirplaneFlyweight flyweight, string flightNumber, string destination)
    {
        _flyweight = flyweight;
        FlightNumber = flightNumber;
        Destination = destination;
    }

    public override string ToString()
    {
        return _flyweight.GetInfo(flightNumber: FlightNumber, destination: Destination);
    }
}