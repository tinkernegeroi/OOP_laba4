using OOP_laba4.classes;
using OOP_laba4.services;

namespace OOP_laba4;

/// <summary>
/// Главная форма приложения. Демонстрирует работу паттернов
/// Abstract Factory и Flyweight для создания аэропортов и самолётов.
/// </summary>
public partial class MainForm : Form
{
    /// <summary>
    /// Фабрика для создания объектов со случайными характеристиками.
    /// </summary>
    private readonly AbstractFactory _factoryRnd = new RandomAbstractFactory();

    /// <summary>
    /// Фабрика для создания объектов премиум-класса.
    /// </summary>
    private readonly AbstractFactory _factoryPrem = new PremiumAbstractFactory();

    /// <summary>
    /// Инициализирует компоненты формы.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Обработчик кнопки «Назад» — закрывает текущую форму.
    /// </summary>
    private void button_Back_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    /// <summary>
    /// Обработчик кнопки «Выход» — завершает работу приложения.
    /// </summary>
    private void button_Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    /// <summary>
    /// Обработчик кнопки создания случайного семейства объектов.
    /// Создаёт один <see cref="Airport"/> и один <see cref="Airplane"/>
    /// через <see cref="RandomAbstractFactory"/> и выводит их в текстовое поле.
    /// </summary>
    private void button_CreateRndFam_Click(object sender, EventArgs e)
    {
        var airport = _factoryRnd.CreateAirport();
        var airplane = _factoryRnd.CreateAirplane();

        textBox_FactoryObj.Text += airport.ToString() + Environment.NewLine;
        textBox_FactoryObj.Text += airplane.ToString() + Environment.NewLine;
    }

    /// <summary>
    /// Обработчик кнопки создания премиум-семейства объектов.
    /// Создаёт один <see cref="Airport"/> и один <see cref="Airplane"/>
    /// через <see cref="PremiumAbstractFactory"/> и выводит их в текстовое поле.
    /// </summary>
    private void button_CreatePremiumRndFam_Click(object sender, EventArgs e)
    {
        var airport = _factoryPrem.CreateAirport();
        var airplane = _factoryPrem.CreateAirplane();

        textBox_FactoryObj.Text += airport.ToString() + Environment.NewLine;
        textBox_FactoryObj.Text += airplane.ToString() + Environment.NewLine;
    }

    /// <summary>
    /// Обработчик кнопки демонстрации паттерна Flyweight.
    /// Создаёт 10 рейсов через <see cref="RandomAbstractFactory"/>, выводит их список
    /// и показывает количество уникальных легковесов в кэше фабрики.
    /// </summary>
    private void button_Flyweight_Click(object sender, EventArgs e)
    {
        var contexts = new List<Airplane>();

        for (int i = 0; i < 10; i++)
        {
            contexts.Add(_factoryRnd.CreateAirplane());
        }

        textBox_Flyweight.Clear();
        textBox_Flyweight.Text += $"Создано рейсов: {contexts.Count}\n" + Environment.NewLine;
        textBox_Flyweight.Text += $"Уникальных шаблонов самолётов в кэше: " +
                                  $"{RandomAbstractFactory.FlyweightCacheSize}" + Environment.NewLine;

        foreach (var ctx in contexts)
            textBox_Flyweight.Text += ctx.ToString() + Environment.NewLine;
    }
}