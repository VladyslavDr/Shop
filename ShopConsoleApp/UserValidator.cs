using log4net;
using ShopConsoleApp.Exceptions;
using ShopConsoleApp.Services;
using System.Text.RegularExpressions;

namespace ShopConsoleApp;

public static class UserValidator
{
    private const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; //todo прочитати про регулярку
    private static readonly List<ApplicationException> _applicationExceptions = new();

    private static bool IsCorrectEmail(string email) => Regex.IsMatch(email, EmailRegex);
    private static bool IsCorrectPassword(string password) => !string.IsNullOrEmpty(password);

    public static List<ApplicationException> ValidateUserExceptions(string email, string password)
    {
        if (!IsCorrectEmail(email))
        {
            _applicationExceptions.Add(new InvalidEmailException(email));
        }

        if (!IsCorrectPassword(password))
        {
            _applicationExceptions.Add(new InvalidPasswordException());
        }

        return _applicationExceptions;
    }
}