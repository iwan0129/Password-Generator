using System;

namespace Password_Generator
{
    internal interface IGenerator<T> : IDisposable
    {
        #region Public Properties

        bool UseBigLetters { get; set; }

        bool UseDigits { get; set; }

        bool UseLetters { get; set; }

        bool UseSpace { get; set; }

        bool UseSymbols { get; set; }

        #endregion Public Properties

        #region Public Methods

        T Generate();

        #endregion Public Methods
    }
}