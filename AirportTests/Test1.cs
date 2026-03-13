using OOP_laba4.classes;

namespace AirportTests;
using OOP_laba4;

[TestClass]
public sealed class Test1
{
    /// <summary>
    /// Проверяет, что конструктор AirplaneFlyweight корректно сохраняет переданные свойства.
    /// </summary>
    [TestMethod]
    public void AirplaneFlyweight_Constructor_SetsPropertiesCorrectly()
    {
        var flyweight = new AirplaneFlyweight("Boeing 737", 150, 5000);
 
        Assert.AreEqual("Boeing 737", flyweight.Model);
        Assert.AreEqual(150, flyweight.Capacity);
        Assert.AreEqual(5000, flyweight.RangeKm);
    }
 
    /// <summary>
    /// Проверяет, что GetInfo возвращает строку, содержащую модель самолёта.
    /// </summary>
    [TestMethod]
    public void AirplaneFlyweight_GetInfo_ContainsModel()
    {
        var flyweight = new AirplaneFlyweight("Airbus A320", 180, 6000);
 
        string info = flyweight.GetInfo("SU-123", "Москва");
 
        StringAssert.Contains(info, "Airbus A320");
    }
 
    /// <summary>
    /// Проверяет, что GetInfo содержит переданный номер рейса.
    /// </summary>
    [TestMethod]
    public void AirplaneFlyweight_GetInfo_ContainsFlightNumber()
    {
        var flyweight = new AirplaneFlyweight("Superjet 100", 100, 3000);
 
        string info = flyweight.GetInfo("SU-999", "Казань");
 
        StringAssert.Contains(info, "SU-999");
    }
 
    /// <summary>
    /// Проверяет, что GetInfo содержит переданный пункт назначения.
    /// </summary>
    [TestMethod]
    public void AirplaneFlyweight_GetInfo_ContainsDestination()
    {
        var flyweight = new AirplaneFlyweight("Boeing 737", 150, 5000);
 
        string info = flyweight.GetInfo("SU-200", "Новосибирск");
 
        StringAssert.Contains(info, "Новосибирск");
    }
 
    /// <summary>
    /// Проверяет, что GetInfo содержит вместимость и дальность полёта.
    /// </summary>
    [TestMethod]
    public void AirplaneFlyweight_GetInfo_ContainsCapacityAndRange()
    {
        var flyweight = new AirplaneFlyweight("Airbus A320", 180, 6000);
 
        string info = flyweight.GetInfo("SU-321", "Сочи");
 
        StringAssert.Contains(info, "180");
        StringAssert.Contains(info, "6000");
    }
 
    // ─────────────────────────────────────────────
    // AirplaneFlyweightFactory
    // ─────────────────────────────────────────────
 
    /// <summary>
    /// Проверяет, что при первом запросе модели кэш содержит ровно один элемент.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_CacheSizeIncrementsOnNewModel()
    {
        var factory = new AirplaneFlyweightFactory();
 
        factory.GetFlyweight("Boeing 737");
 
        Assert.AreEqual(1, factory.CacheSize);
    }
 
    /// <summary>
    /// Проверяет, что повторный запрос той же модели не увеличивает размер кэша.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_SameModelReturnsSameCacheSize()
    {
        var factory = new AirplaneFlyweightFactory();
 
        factory.GetFlyweight("Boeing 737");
        factory.GetFlyweight("Boeing 737");
 
        Assert.AreEqual(1, factory.CacheSize);
    }
 
    /// <summary>
    /// Проверяет, что два запроса одной модели возвращают один и тот же объект (ссылочное равенство).
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_SameModelReturnsSameInstance()
    {
        var factory = new AirplaneFlyweightFactory();
 
        var fw1 = factory.GetFlyweight("Airbus A320");
        var fw2 = factory.GetFlyweight("Airbus A320");
 
        Assert.AreSame(fw1, fw2);
    }
 
    /// <summary>
    /// Проверяет, что разные модели возвращают разные объекты.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_DifferentModelsReturnDifferentInstances()
    {
        var factory = new AirplaneFlyweightFactory();
 
        var fw1 = factory.GetFlyweight("Boeing 737");
        var fw2 = factory.GetFlyweight("Airbus A320");
 
        Assert.AreNotSame(fw1, fw2);
    }
 
    /// <summary>
    /// Проверяет, что после добавления трёх разных моделей размер кэша равен трём.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_ThreeDistinctModels_CacheSizeIsThree()
    {
        var factory = new AirplaneFlyweightFactory();
 
        factory.GetFlyweight("Boeing 737");
        factory.GetFlyweight("Airbus A320");
        factory.GetFlyweight("Superjet 100");
 
        Assert.AreEqual(3, factory.CacheSize);
    }
 
    /// <summary>
    /// Проверяет, что для известной предопределённой модели ("Boeing 737")
    /// возвращается легковес с корректными характеристиками.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_KnownModel_ReturnsCorrectSpecs()
    {
        var factory = new AirplaneFlyweightFactory();
 
        var fw = factory.GetFlyweight("Boeing 737");
 
        Assert.AreEqual("Boeing 737", fw.Model);
        Assert.AreEqual(150, fw.Capacity);
        Assert.AreEqual(5000, fw.RangeKm);
    }
 
    /// <summary>
    /// Проверяет, что для неизвестной модели фабрика всё равно создаёт легковес
    /// (с произвольными характеристиками) и добавляет его в кэш.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_GetFlyweight_UnknownModel_CreatesAndCaches()
    {
        var factory = new AirplaneFlyweightFactory();
 
        var fw = factory.GetFlyweight("Unknown Jet X");
 
        Assert.IsNotNull(fw);
        Assert.AreEqual("Unknown Jet X", fw.Model);
        Assert.AreEqual(1, factory.CacheSize);
    }
 
    /// <summary>
    /// Проверяет, что начальный размер кэша новой фабрики равен нулю.
    /// </summary>
    [TestMethod]
    public void FlyweightFactory_InitialCacheSize_IsZero()
    {
        var factory = new AirplaneFlyweightFactory();
 
        Assert.AreEqual(0, factory.CacheSize);
    }
 
    // ─────────────────────────────────────────────
    // Airplane (контекст Flyweight)
    // ─────────────────────────────────────────────
 
    /// <summary>
    /// Проверяет, что конструктор Airplane корректно сохраняет номер рейса и пункт назначения.
    /// </summary>
    [TestMethod]
    public void Airplane_Constructor_SetsExternalState()
    {
        var fw = new AirplaneFlyweight("Boeing 737", 150, 5000);
        var airplane = new Airplane(fw, "SU-100", "Казань");
 
        Assert.AreEqual("SU-100", airplane.FlightNumber);
        Assert.AreEqual("Казань", airplane.Destination);
    }
 
    /// <summary>
    /// Проверяет, что ToString содержит номер рейса.
    /// </summary>
    [TestMethod]
    public void Airplane_ToString_ContainsFlightNumber()
    {
        var fw = new AirplaneFlyweight("Airbus A320", 180, 6000);
        var airplane = new Airplane(fw, "SU-555", "Сочи");
 
        string result = airplane.ToString();
 
        StringAssert.Contains(result, "SU-555");
    }
 
    /// <summary>
    /// Проверяет, что ToString содержит пункт назначения.
    /// </summary>
    [TestMethod]
    public void Airplane_ToString_ContainsDestination()
    {
        var fw = new AirplaneFlyweight("Airbus A320", 180, 6000);
        var airplane = new Airplane(fw, "SU-555", "Сочи");
 
        string result = airplane.ToString();
 
        StringAssert.Contains(result, "Сочи");
    }
 
    /// <summary>
    /// Проверяет, что ToString содержит модель из легковеса.
    /// </summary>
    [TestMethod]
    public void Airplane_ToString_ContainsModelFromFlyweight()
    {
        var fw = new AirplaneFlyweight("Superjet 100", 100, 3000);
        var airplane = new Airplane(fw, "SU-777", "Пермь");
 
        string result = airplane.ToString();
 
        StringAssert.Contains(result, "Superjet 100");
    }
 
    /// <summary>
    /// Проверяет, что два объекта Airplane с одним легковесом, но разными рейсами
    /// возвращают разные строки ToString (разное внешнее состояние).
    /// </summary>
    [TestMethod]
    public void Airplane_ToString_DifferentContexts_ProduceDifferentOutput()
    {
        var fw = new AirplaneFlyweight("Boeing 737", 150, 5000);
        var airplane1 = new Airplane(fw, "SU-101", "Москва");
        var airplane2 = new Airplane(fw, "SU-202", "Екатеринбург");
 
        Assert.AreNotEqual(airplane1.ToString(), airplane2.ToString());
    }
 
    /// <summary>
    /// Проверяет, что два объекта Airplane с одним легковесом и одинаковым внешним состоянием
    /// возвращают одинаковые строки ToString.
    /// </summary>
    [TestMethod]
    public void Airplane_ToString_SameContext_ProduceSameOutput()
    {
        var fw = new AirplaneFlyweight("Boeing 737", 150, 5000);
        var airplane1 = new Airplane(fw, "SU-101", "Москва");
        var airplane2 = new Airplane(fw, "SU-101", "Москва");
 
        Assert.AreEqual(airplane1.ToString(), airplane2.ToString());
    }
 
    /// <summary>
    /// Проверяет, что несколько объектов Airplane могут разделять один и тот же экземпляр легковеса
    /// (паттерн Flyweight работает корректно).
    /// </summary>
    [TestMethod]
    public void Airplane_MultipleAirplanes_ShareSameFlyweightInstance()
    {
        var factory = new AirplaneFlyweightFactory();
        var fw = factory.GetFlyweight("Boeing 737");
 
        var airplanes = new List<Airplane>();
        for (int i = 0; i < 5; i++)
            airplanes.Add(new Airplane(fw, $"SU-{i}", "Пулково"));
 
        // Все рейсы используют один объект-легковес — кэш не вырос
        Assert.AreEqual(1, factory.CacheSize);
 
        // Каждый рейс содержит модель из разделяемого легковеса
        foreach (var a in airplanes)
            StringAssert.Contains(a.ToString(), "Boeing 737");
    }
}