using greenlox;

var scanner = new Scanner("\"Hello world\"");
var tokens = scanner.ScanTokens();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}

if (ErrorHandler.HadError)
{
    Console.WriteLine(ErrorHandler.ErrorMessage);
}
