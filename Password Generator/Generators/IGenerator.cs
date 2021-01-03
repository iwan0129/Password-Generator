using System;

namespace Password_Generator.Generators
{
    internal interface IGenerator<T> : IDisposable
    {
        bool UseBigLetters { get; set; }
       
        bool UseDigits { get; set; }
       
        bool UseLetters { get; set; }
       
        bool UseSpace { get; set; }
        
        bool UseSymbols { get; set; }
       
        T Generate();
    }
}