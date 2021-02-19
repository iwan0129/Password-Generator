using System.Windows.Input;

namespace Password_Generator.Utilities
{
    internal static class Extensions
    {
        public static char ConvertToChar(this Key key)
        {
            if (key >= Key.A && key <= Key.Z)
            {
                return (char)('a' + (key - Key.A));
            }
            else if (key >= Key.D0 && key <= Key.D9)
            {
                return (char)('0' + (key - Key.D0));
            }

            return '\0';
        }
    }
}