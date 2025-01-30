using greenlox;

var scanner = new Scanner("fun (num)\n{ return num + 1 }");
var tokens = scanner.ScanTokens();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}

if (ErrorHandler.HadError)
{
    Console.WriteLine(ErrorHandler.ErrorMessage);
}
