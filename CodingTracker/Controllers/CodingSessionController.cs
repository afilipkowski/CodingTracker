using CodingTracker.Helpers;
using CodingTracker.Models;
using Spectre.Console;

namespace CodingTracker.Controllers;

internal class CodingSessionController
{
    private readonly Database db = new Database();
    public void RecordSession()
    {
        DateTime startTime;
        DateTime endTime;

        startTime = InputHelper.GetDateInput("start");
        endTime = InputHelper.GetDateInput("end");

        if (startTime > endTime)
        {
            AnsiConsole.MarkupLine("[red]End time cannot be before start time.[/]");
            return;
        }

        var session = new CodingSession
        {
            StartTime = startTime,
            EndTime = endTime,
            Duration = endTime - startTime
        };
        db.AddSession(session);
    }
}