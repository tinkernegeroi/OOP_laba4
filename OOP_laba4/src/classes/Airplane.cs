namespace OOP_laba4.classes;

/// <summary>
/// Представляет конкретный рейс самолёта (контекст паттерна Flyweight).
/// Хранит внешнее состояние (номер рейса и пункт назначения),
/// а внутреннее состояние делегирует объекту <see cref="AirplaneFlyweight"/>.
/// </summary>
public class Airplane
{
    /// <summary>
    /// Разделяемый объект-легковес, содержащий общие характеристики типа самолёта.
    /// </summary>
    private readonly AirplaneFlyweight _flyweight;

    /// <summary>
    /// Уникальный номер рейса (внешнее состояние).
    /// </summary>
    public string FlightNumber { get; }

    /// <summary>
    /// Пункт назначения рейса (внешнее состояние).
    /// </summary>
    public string Destination { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Airplane"/> с указанным легковесом
    /// и внешними данными рейса.
    /// </summary>
    /// <param name="flyweight">Общий объект с характеристиками типа самолёта.</param>
    /// <param name="flightNumber">Номер рейса.</param>
    /// <param name="destination">Пункт назначения.</param>
    public Airplane(AirplaneFlyweight flyweight, string flightNumber, string destination)
    {
        _flyweight = flyweight;
        FlightNumber = flightNumber;
        Destination = destination;
    }

    /// <summary>
    /// Возвращает строковое представление рейса, объединяя внутренние данные
    /// легковеса с внешним состоянием данного объекта.
    /// </summary>
    /// <returns>Строка с полным описанием рейса.</returns>
    public override string ToString()
    {
        return _flyweight.GetInfo(flightNumber: FlightNumber, destination: Destination);
    }
}