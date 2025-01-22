Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.White;
Console.WriteLine("Красный текст на белом фоне");

Console.ResetColor();
Console.WriteLine("Обычный текст");

Console.WriteLine(new String('-', 80));
foreach (var color in Enum.GetValues<ConsoleColor>())
{
    Console.ForegroundColor = color;
    Console.WriteLine(color);
    Console.ResetColor();
}