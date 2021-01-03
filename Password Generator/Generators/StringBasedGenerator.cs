namespace Password_Generator.Generators
{
    internal abstract class StringBasedGenerator : IGenerator<string>
    {
        public const string BigLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public const string Digits = "1234567890";
        public const string Letters = "qwertyuiopasdfghjklzxcvbnm";
        public const string Symbols = @"!@#$%^&*()_+-=\|{}[]:;/.>?<`~";

        public abstract bool UseBigLetters { get; set; }

        public abstract bool UseDigits { get; set; }

        public abstract bool UseLetters { get; set; }

        public abstract bool UseSpace { get; set; }

        public abstract bool UseSymbols { get; set; }

        public abstract void Dispose();

        public abstract string Generate();
    }
}
