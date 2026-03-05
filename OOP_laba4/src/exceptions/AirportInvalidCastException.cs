using System;

namespace OOP_laba4.exceptions;

public class AirportInvalidCastException : Exception
{
    public AirportInvalidCastException() 
        : base("Ошибка приведения типа.") { }

    public AirportInvalidCastException(string message) 
        : base(message) { }
}