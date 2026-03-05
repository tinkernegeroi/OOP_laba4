using OOP_laba4.classes;

namespace OOP_laba4.services;

public class ListEventListener
{
    private TextBox _textBox;

    public ListEventListener(AirportCollection list, TextBox textBox)
    {
        this._textBox = textBox;
        list.ItemAdded += (message) => { this._textBox.Text += message; };
        list.ItemRemoved += (message) => { this._textBox.Text += message; };
    }
}