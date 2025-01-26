using System.Globalization;
using Spectre.Console;

namespace CodingTracker.Helpers;

internal class InputHelper
{
    internal static DateTime GetDateInput(string message)
    {
        DateTime dateTime;
        string userInput;

        AnsiConsole.MarkupLine($"Enter the {message} time of the coding session (dd.mm.yyyy hh:mm):");
        userInput = Console.ReadLine();
        while (!DateTime.TryParseExact(userInput, "dd.MM.yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime))
        {
            AnsiConsole.MarkupLine("[red]Invalid input. Enter the date in (dd.mm.yyyy hh:mm)format.[/]");
            userInput = Console.ReadLine();
        }
        return dateTime;
    }
}