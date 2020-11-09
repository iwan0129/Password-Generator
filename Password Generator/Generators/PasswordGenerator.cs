using System;
using System.Text;

namespace Password_Generator
{
    internal class PasswordGenerator : IGenerator<string>
    {
        private const string BigLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string Digits = "1234567890";
        private const string Letters = "qwertyuiopasdfghjklzxcvbnm";
        private const string Symbols = @"!@#$%^&*()_+-=\|{}[]:;/.>?<`~";

        private readonly Random Random;

        private bool Disposed;

        public int Length;

        public bool UseBigLetters { get; set; }

        public bool UseDigits { get; set; }

        public bool UseLetters { get; set; }

        public bool UseSpace { get; set; }

        public bool UseSymbols { get; set; }

        public PasswordGenerator()
        {
            Random = new Random();
        }

        ~PasswordGenerator()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                Disposed = true;

                UseDigits = UseLetters = UseBigLetters = UseSymbols = UseSpace = false;

                Length = 0;

                if (disposing)
                {
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public string Generate()
        {
            if ((!UseDigits && !UseLetters && !UseBigLetters && !UseSymbols) || Length == 0)
            {
                return null;
            }

            Random.Next(0, int.MaxValue);

            char[] generation = new char[Length];

            int offset = 0;

            for (int i = 0; i < Length; i++)
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
                        if (UseSpace && i > 0 && i < Length - 1)
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

                generation[offset++] = c;
            }

            return new string(generation, 0, generation.Length);
        }
    }
}