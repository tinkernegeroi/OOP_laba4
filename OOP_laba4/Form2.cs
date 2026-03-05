using OOP_laba4.classes;
using OOP_laba4.services;
using OOP_laba4.utils;

namespace OOP_laba4;

public partial class Form2 : Form
{
    private AirportCollection _list;
    
    private readonly AbstractFactory _factoryRnd = new RandomAbstractFactory();
    
    private readonly AbstractFactory _factoryPrem =  new PremiumAbstractFactory();
    
    private ListEventListener _listener;
    public Form2()
    {
        InitializeComponent();
    }
    private void button_Back_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button_Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    

    private void button_CreateRndFam_Click(object sender, EventArgs e)
    {
        var airport = _factoryRnd.CreateAirport();
        var airplane = _factoryRnd.CreateAirplane();
        
        textBox_FactoryObj.Text += airport.ToString() + Environment.NewLine;
        textBox_FactoryObj.Text += airplane.ToString() + Environment.NewLine;

    }

    private void button_CreatePremiumRndFam_Click(object sender, EventArgs e)
    {
        var airport = _factoryPrem.CreateAirport();
        var airplane = _factoryPrem.CreateAirplane();
        
        textBox_FactoryObj.Text += airport.ToString() + Environment.NewLine;
        textBox_FactoryObj.Text += airplane.ToString() + Environment.NewLine;
    }

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