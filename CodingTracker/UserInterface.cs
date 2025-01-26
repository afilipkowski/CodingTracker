using CodingTracker.Controllers;
using Spectre.Console;
using static CodingTracker.Enums;

namespace CodingTracker;

internal class UserInterface
{
    private readonly CodingSessionController _codingSessionController = new CodingSessionController();
    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                .Title("What do you want to do?")
                .AddChoices(Enum.GetValues<MenuOption>()));

            switch (menuChoice)
            {
                case MenuOption.AddSession:
                    _codingSessionController.RecordSession();
                    break;
            }
        }
    }
}
