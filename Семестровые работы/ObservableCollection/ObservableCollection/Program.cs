using System.Collections.ObjectModel;

internal class Program
{
    private static void Main(string[] args)
    {
        var cities = new ObservableCollection <string> ();
        cities.Add("Москва");

        Console.WriteLine("Команды: ");
        Console.WriteLine("+ <город> - добавить город");
        Console.WriteLine("- <город> - удалить город");
        Console.WriteLine("?         - показать все города");
        Console.WriteLine("[Enter]   - выход");

        while (true)
        {
            var newLine = Console.ReadLine ();
            
            if (String.IsNullOrEmpty (newLine))
                break;
            switch (newLine)
            {
                case "?":
                    Console.WriteLine($"Города ({cities.Count}): ");
                    Console.WriteLine(String.Join(",", cities));
                    break;
                default:
                    var cmd = newLine.Split (' ');
                    switch (cmd[0])
                    {
                        case "+":
                            //TODO
                            break;
                    case "-":
                            break;
                    }
                    break;
            }
        }
    }
}