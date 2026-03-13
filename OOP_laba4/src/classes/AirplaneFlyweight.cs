namespace OOP_laba4.classes;

/// <summary>
/// Легковес (Flyweight) — хранит общие (внутренние) данные о типе самолёта,
/// которые разделяются между множеством объектов <see cref="Airplane"/>.
/// </summary>
public class AirplaneFlyweight
{
    /// <summary>
    /// Модель самолёта (например, "Boeing 737").
    /// </summary>
    public string Model { get; }

    /// <summary>
    /// Вместимость самолёта (количество пассажирских мест).
    /// </summary>
    public int Capacity { get; }

    /// <summary>
    /// Максимальная дальность полёта в километрах.
    /// </summary>
    public double RangeKm { get; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="AirplaneFlyweight"/>
    /// с указанными характеристиками самолёта.
    /// </summary>
    /// <param name="model">Модель самолёта.</param>
    /// <param name="capacity">Вместимость (количество мест).</param>
    /// <param name="rangeKm">Дальность полёта в километрах.</param>
    public AirplaneFlyweight(string model, int capacity, double rangeKm)
    {
        Model = model;
        Capacity = capacity;
        RangeKm = rangeKm;
    }

    /// <summary>
    /// Формирует строку с полной информацией о рейсе, объединяя внутренние данные
    /// легковеса (модель, вместимость, дальность) с внешними данными контекста
    /// (номер рейса и пункт назначения).
    /// </summary>
    /// <param name="flightNumber">Номер рейса (внешнее состояние).</param>
    /// <param name="destination">Пункт назначения (внешнее состояние).</param>
    /// <returns>Отформатированная строка с описанием рейса.</returns>
    public string GetInfo(string flightNumber, string destination)
    {
        return $"Самолет: {Model}, Вместимость: {Capacity}, " +
               $"Дальность: {RangeKm} км | " +
               $"Рейс: {flightNumber} → {destination}";
    }
}