using System;

namespace Password_Generator
{
    internal class SerialKeyGenerator : IGenerator<string>
    {
        #region Private Fields

        private const string BigLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string Digits = "1234567890";
        private const string Letters = "qwertyuiopasdfghjklzxcvbnm";
        private const string Symbols = @"!@#$%^&*()_+-=\|{}[]:;/.>?<`~";

        private readonly Random Random;

        private bool Disposed;

        #endregion Private Fields

        #region Public Fields

        public int Length;

        public int Size;

        #endregion Public Fields

        #region Public Constructors

        public SerialKeyGenerator()
        {
            Random = new Random();
        }

        #endregion Public Constructors

        #region Private Destructors

        ~SerialKeyGenerator()
        {
            Dispose(false);
        }

        #endregion Private Destructors

        #region Public Properties

        public bool UseBigLetters { get; set; }
        public bool UseDigits { get; set; }
        public bool UseLetters { get; set; }
        public bool UseSpace { get; set; }
        public bool UseSymbols { get; set; }

        #endregion Public Properties

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;

                UseDigits = UseLetters = UseBigLetters = UseSymbols = UseSpace = false;

                Length = Size = 0;

                if (disposing)
                {
                }
            }
        }

        #endregion Protected Methods

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public string Generate()
        {
            if ((!UseDigits && !UseLetters && !UseBigLetters && !UseSymbols) || (Length == 0 && Size == 0))
            {
                return null;
            }

            Random.Next(0, int.MaxValue);

            char[] generation = new char[Length * Size * 2];

            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                for (int p = 0; p < Size; p++)
                {
                start:

                    char c;

                    switch (Random.Next(1, 6))
                    {
                        case 1:
                            if (UseLetters)
                            {
                                c = Letters[Random.Next(0, Letters.Length)];
                            }
                            else
                            {
                                goto start;
                            }
                            break;

                        case 2:
                            if (UseBigLetters)
                            {
                                c = BigLetters[Random.Next(0, BigLetters.Length)];
                            }
                            else
                            {
                                goto start;
                            }
                            break;

                        case 3:
                            if (UseDigits)
                            {
                                c = Digits[Random.Next(0, Digits.Length)];
                            }
                            else
                            {
                                goto start;
                            }
                            break;

                        case 4:
                            if (UseSpace && p > 0 && p < Size - 1)
                            {
                                c = ' ';
                            }
                            else
                            {
                                goto start;
                            }
                            break;

                        case 5:
                            if (UseSymbols)
                            {
                                c = Symbols[Random.Next(0, Symbols.Length)];
                            }
                            else
                            {
                                goto start;
                            }
                            break;

                        default:
                            c = '\0';
                            break;
                    }

                    generation[index++] = c;
                }

                if (i < Length - 1)
                {
                    generation[index++] = '-';
                }
            }

            return new string(generation);
        }

        #endregion Public Methods
    }
}