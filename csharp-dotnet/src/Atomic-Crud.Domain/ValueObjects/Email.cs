using Ardalis.Result;
using Atomic_Crud.Domain.Utils;

namespace Atomic_Crud.Domain.ValueObjects
{
    public sealed partial record Email
    {
        private const int MaxLength = 254;

        private Email(string value)
        {
            var atIndex = value.IndexOf('@');

            Value = value;
            Local = value[..atIndex];
            Domain = value[(atIndex + 1)..];
        }

        public string Value { get; }
        public string Local { get; }
        public string Domain { get; }

        public static Result<Email> Create(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return Result<Email>.Error("The e-mail address must be provided.");
            }

            if (emailAddress.Length > MaxLength)
            {
                return Result<Email>.Error($"The e-mail address must not exceed {MaxLength} characters.");
            }

            if (!RegexPatterns.IsValidEmail.IsMatch(emailAddress))
            {
                return Result<Email>.Error("The e-mail address is not in a valid format.");
            }

            return Result<Email>.Success(new Email(emailAddress));
        }
    }
}
