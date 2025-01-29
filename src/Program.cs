using greenlox;

var scanner = new Scanner(">=");
var tokens = scanner.ScanTokens();

Console.WriteLine(tokens[0]);

if (ErrorHandler.HadError)
{
    Console.WriteLine(ErrorHandler.ErrorMessage);
}
