using greenlox;

var scanner = new Scanner("// this is a comment\r\n(( )){} // grouping stuff\r\n!*+-/=<> <= == // operators");
var tokens = scanner.ScanTokens();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}

if (ErrorHandler.HadError)
{
    Console.WriteLine(ErrorHandler.ErrorMessage);
}
