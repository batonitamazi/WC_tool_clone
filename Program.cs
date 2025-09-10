using System.Text;
using CCWC.Helpers;
string[] arguments = Environment.GetCommandLineArgs().Skip(1).ToArray(); // skip exe name

if (arguments.Length == 0)
{
    Console.WriteLine("Usage: CCWC <options> <file>");
    return;
}

if (arguments.Length == 1 && !arguments[0].StartsWith("-"))
{
    // default: only filename provided → run -l -w -c
    Helpers.FileReader(arguments[0]); 
}
else
{
    string option = arguments[0];
    string? path = arguments.Length > 1 ? arguments[1] : null;

    if (path is not null)
    {
       Helpers.FileReader(option, path);
    }
    else
    {
        using var reader = new StreamReader(Console.OpenStandardInput(), Encoding.UTF8);
        string input = reader.ReadToEnd();
        Helpers.FileReaderFromStdin(option, input);
    }
}