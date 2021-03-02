using System;

namespace Password_Generator.Generators
{
    internal class PasswordGenerator : StringBasedGenerator
    {
        private readonly Random Random;

        private bool disposed;

        public int Length;

        public sealed override bool UseBigLetters { get; set; }

        public sealed override bool UseDigits { get; set; }

        public sealed override bool UseLetters { get; set; }

        public sealed override bool UseSpace { get; set; }

        public sealed override bool UseSymbols { get; set; }

        public PasswordGenerator()
        {
            Random = new();
        }

        ~PasswordGenerator()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;

                UseDigits = UseLetters = UseBigLetters = UseSymbols = UseSpace = false;

                Length = 0;

                if (disposing)
                {
                }
            }
        }

        public sealed override void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public sealed override string Generate()
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

                char value;

                switch (Random.Next(1, 6))
                {
                    case 1:

                        if (UseLetters)
                        {
                            value = Letters[Random.Next(0, Letters.Length)];
                        }
                        else
                        {
                            goto start;
                        }

                        break;

                    case 2:

                        if (UseBigLetters)
                        {
                            value = BigLetters[Random.Next(0, BigLetters.Length)];
                        }
                        else
                        {
                            goto start;
                        }

                        break;

                    case 3:

                        if (UseDigits)
                        {
                            value = Digits[Random.Next(0, Digits.Length)];
                        }
                        else
                        {
                            goto start;
                        }

                        break;

                    case 4:

                        if (UseSpace && i > 0 && i < Length - 1)
                        {
                            value = ' ';
                        }
                        else
                        {
                            goto start;
                        }

                        break;

                    case 5:

                        if (UseSymbols)
                        {
                            value = Symbols[Random.Next(0, Symbols.Length)];
                        }
                        else
                        {
                            goto start;
                        }

                        break;

                    default:

                        value = '\0';

                        break;
                }

                generation[offset++] = value;
            }

            return new(generation, 0, offset);
        }
    }
}