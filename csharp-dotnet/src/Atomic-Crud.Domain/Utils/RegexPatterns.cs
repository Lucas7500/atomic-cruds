using System.Text.RegularExpressions;

namespace Atomic_Crud.Domain.Utils
{
    public static partial class RegexPatterns
    {
        public static readonly Regex IsValidEmail = EmailRegexPattern();

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegexPattern();
    }
}
