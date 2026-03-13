using OOP_laba4.exceptions;

namespace OOP_laba4.classes;

/// <summary>
/// Представляет аэропорт с основными характеристиками:
/// названием, местоположением, статистикой полётов, балансом и рейтингом.
/// </summary>
public class Airport
{
    /// <summary>
    /// Общее количество созданных объектов <see cref="Airport"/> за время работы приложения.
    /// Увеличивается на 1 при каждом вызове конструктора.
    /// </summary>
    public static int ObjectsCount { get; private set; } = 0;

    /// <summary>
    /// Название аэропорта.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Местоположение аэропорта (город или страна).
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// Количество вылетов за день.
    /// </summary>
    public int FlightsPerDay { get; set; }

    /// <summary>
    /// Количество проданных билетов за день.
    /// </summary>
    public int TicketsSold { get; set; }

    private decimal _balance;

    /// <summary>
    /// Баланс аэропорта в денежных единицах.
    /// Не может быть отрицательным; при попытке установить отрицательное значение
    /// выбрасывается исключение <see cref="AirportInvalidCastException"/>.
    /// </summary>
    /// <exception cref="AirportInvalidCastException">
    /// Выбрасывается, если присваиваемое значение меньше нуля.
    /// </exception>
    public decimal Balance
    {
        get { return _balance; }
        set
        {
            if (value < 0)
                throw new AirportInvalidCastException("Значение не может быть отрицательным");
            _balance = value;
        }
    }

    /// <summary>
    /// Рейтинг аэропорта (от 0.0 до 5.0).
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Количество сотрудников аэропорта.
    /// </summary>
    public int EmployeesCount { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Airport"/> со значениями по умолчанию.
    /// Увеличивает счётчик <see cref="ObjectsCount"/>.
    /// </summary>
    public Airport()
    {
        Name = "";
        Location = "";
        FlightsPerDay = 0;
        TicketsSold = 0;
        Balance = 0;
        Rating = 0;
        EmployeesCount = 0;
        ObjectsCount++;
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Airport"/> с указанным названием.
    /// </summary>
    /// <param name="name">Название аэропорта.</param>
    public Airport(string name) : this()
    {
        Name = name;
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Airport"/> с названием и местоположением.
    /// </summary>
    /// <param name="name">Название аэропорта.</param>
    /// <param name="location">Местоположение аэропорта.</param>
    public Airport(string name, string location) : this(name)
    {
        Location = location;
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Airport"/> со всеми основными характеристиками.
    /// </summary>
    /// <param name="name">Название аэропорта.</param>
    /// <param name="location">Местоположение аэропорта.</param>
    /// <param name="flightsPerDay">Количество вылетов за день.</param>
    /// <param name="ticketsSold">Количество проданных билетов за день.</param>
    /// <param name="balance">Баланс аэропорта (не может быть отрицательным).</param>
    /// <param name="rating">Рейтинг аэропорта.</param>
    /// <param name="employeesCount">Количество сотрудников.</param>
    public Airport(
        string name,
        string location,
        int flightsPerDay,
        int ticketsSold,
        decimal balance,
        double rating,
        int employeesCount
        ) : this(name, location)
    {
        FlightsPerDay = flightsPerDay;
        TicketsSold = ticketsSold;
        Balance = balance;
        Rating = rating;
        EmployeesCount = employeesCount;
    }

    /// <summary>
    /// Возвращает строковое представление аэропорта со всеми характеристиками,
    /// включая количество вылетов в шестнадцатеричном формате.
    /// </summary>
    /// <returns>Многострочная строка с описанием аэропорта.</returns>
    public override string ToString()
    {
        return $"Аэропорт: {Name},\n" +
               $" Местоположение: {Location},\n" +
               $" Полетов за день: {FlightsPerDay},\n" +
               $"Полетов за день HEX: {GetFlightsPerDayHex()}, \n" +
               $" Продано билетов за день: {TicketsSold},\n" +
               $" Баланс: {Balance:C},\n" +
               $" Рейтинг: {Rating},\n" +
               $" Количество сотрудников: {EmployeesCount}, \n" +
               $"Объектов создано: {ObjectsCount}";
    }

    /// <summary>
    /// Возвращает количество вылетов за день в шестнадцатеричном представлении (верхний регистр).
    /// </summary>
    /// <returns>Строка с числом <see cref="FlightsPerDay"/> в формате HEX.</returns>
    public string GetFlightsPerDayHex()
    {
        return FlightsPerDay.ToString("X");
    }
}