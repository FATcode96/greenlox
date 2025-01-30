using greenlox;

var scanner = new Scanner("15.123\n\"Hello, world!\"");
var tokens = scanner.ScanTokens();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}

if (ErrorHandler.HadError)
{
    Console.WriteLine(ErrorHandler.ErrorMessage);
}
