using System.Globalization;
using Spectre.Console;

namespace DeleteMe
{

    using Spectre.Console;

    using Spectre.Console;

    class Program
    {
        static void Main()
        {
            // Välkomstmeddelande
            AnsiConsole.MarkupLine("[bold green]Välkommen till kundregistrering![/]");
            AnsiConsole.WriteLine();

            // Hämta information från användaren
            string name = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]namn[/]:")
                    .ValidationErrorMessage("[red]Namnet får inte vara tomt![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            string email = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]e-post[/]:")
                    .ValidationErrorMessage("[red]Ogiltig e-postadress![/]")
                    .Validate(input => input.Contains("@")));

            string address = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]adress[/]:")
                    .ValidationErrorMessage("[red]Adressen får inte vara tom![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            string postcode = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]postnummer[/]:")
                    .ValidationErrorMessage("[red]Postnumret måste innehålla siffror![/]")
                    .Validate(input => int.TryParse(input, out _)));

            string city = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]stad[/]:")
                    .ValidationErrorMessage("[red]Staden får inte vara tom![/]")
                    .Validate(input => !string.IsNullOrWhiteSpace(input)));

            string phone = AnsiConsole.Prompt(
                new TextPrompt<string>("Ange [yellow]telefonnummer[/]:")
                    .ValidationErrorMessage("[red]Telefonnumret måste vara numeriskt![/]")
                    .Validate(input => long.TryParse(input, out _)));

            // Visa sammanfattning
            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Fält[/]");
            table.AddColumn("[red]Värde[/]");
            table.AddRow("Namn", name);
            table.AddRow("E-post", email);
            table.AddRow("Adress", address);
            table.AddRow("Postnummer", postcode);
            table.AddRow("Stad", city);
            table.AddRow("Telefonnummer", phone);
            AnsiConsole.Write(table);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nÄr alla uppgifter korrekta?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Kund registrerad framgångsrikt![/]");
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registrering avbruten.[/]");
            }
        }
    }


}
