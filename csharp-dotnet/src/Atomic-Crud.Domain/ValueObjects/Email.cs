using System.Text.RegularExpressions;

namespace Atomic_Crud.Domain.ValueObjects
{
    public sealed partial record Email
    {
        private const int MaxLength = 254;

        public Email(string value)
        {
            Validate(value);
            
            var atIndex = value.IndexOf('@');

            Value = value;
            Local = value[..atIndex];
            Domain = value[(atIndex + 1)..];
        }

        public string Value { get; }
        public string Local { get; }
        public string Domain { get; }

        private static void Validate(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"Email cannot be longer than {MaxLength} characters.", nameof(value));
            }

            if (!EmailRegex().IsMatch(value))
            {
                throw new ArgumentException("Email is not in a valid format.", nameof(value));
            }
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
    }
}
