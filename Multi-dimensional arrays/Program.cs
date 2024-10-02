////month names
/*
using System.Globalization;
CultureInfo culture = new("en");
string[] months = new string[12];
for (int month = 1; month <= 12; month++)
{
    DateTime firstDay = new(DateTime.Now.Year, month, 1);
    string name = firstDay.ToString("MMMM", culture);
    months[month - 1] = name;
}
foreach (string m in months)
{
    Console.WriteLine(m);
}
*/





//// multiplication table
/*
int[,] results = new int[10, 10];
for (int i = 0; i < results.GetLength(0); i++)
{
    for (int j = 0; j < results.GetLength(1); j++)
    {
        results[i, j] = (i + 1) * (j + 1);
        Console.Write($"{results[i, j], 4}");
    }
    Console.WriteLine();
}
*/



//// game map
/*
using System.Text;

///
ConsoleColor GetColor(char terrain)
{
    return terrain switch
    {
        'g' => ConsoleColor.Green,
        's' => ConsoleColor.Yellow,
        'w' => ConsoleColor.Blue,
        _ => ConsoleColor.DarkGray
    };
}

char GetChar(char terrain)
{
    return terrain switch
    {
        'g' => '\u201c',
        's' => '\u25cb',
        'w' => '\u2248',
        _ => '\u25cf'
    };
}

char[,] map =
{
    { 's', 's', 's', 'g', 'g', 'g', 'g', 'g', 'g', 's', 'w', 'w' },
    { 's', 's', 's', 'g', 'g', 'g', 'g', 'g', 'g', 's', 'w', 'w' },
    { 's', 's', 's', 's', 's', 'b', 'b', 'b', 'g', 's', 'w', 'w' },
    { 's', 's', 's', 's', 's', 'b', 's', 's', 'g', 's', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w', 'g', 's', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'g', 'g', 'g', 's', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 's', 'g', 's', 'w', 'w' },
    { 'g', 's', 'w', 'w', 'w', 'b', 'w', 's', 'g', 's', 'w', 'w' },
    { 'w', 'w', 's', 'w', 'w', 'b', 'b', 'w', 'g', 's', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w', 'g', 's', 'w', 'w' },
    { 'w', 'b', 'w', 'g', 'w', 'b', 's', 'b', 'g', 's', 'w', 'w' },
    { 'g', 'w', 'w', 'g', 'w', 'b', 's', 'g', 'g', 's', 'w', 'w' },
    { 'w', 'w', 'w', 'w', 'w', 'b', 'w', 's', 'g', 's', 'w', 'w' }
};

Console.WriteLine();
Console.OutputEncoding = Encoding.UTF8;
for (int i = 0; i < map.GetLength(0); i++)
{
    for (int j = 0; j < map.GetLength(1); j++)
    {
        Console.ForegroundColor = GetColor(map[i, j]);
        Console.Write(GetChar(map[i, j]));
    }
    Console.WriteLine();
}
Console.ResetColor();
*/




//// yearly transport plan

using System.Globalization;

Random random = new();
int meansCount = Enum.GetNames<MeanEnum>().Length;
int year = DateTime.Now.Year;
MeanEnum[][] means = new MeanEnum[12][];
for (int m = 1; m <= 12; m++)
{
    int daysCount = DateTime.DaysInMonth(year, m);
    means[m - 1] = new MeanEnum[daysCount];
    for (int d = 1; d <= daysCount; d++)
    {
        int mean = random.Next(meansCount);
        means[m - 1][d - 1] = (MeanEnum)mean;
    }
}
string[] GetMonthsNames()
{
    CultureInfo culture = new("en");
    string[] names = new string[12];
    foreach (int i in Enumerable.Range(1, 12))
    {
        DateTime firstDay = new(DateTime.Now.Year, i, 1);
        string name = firstDay.ToString("MMMM", culture);
        names[i - 1] = name;
    }
    return names;
}

(char Char, ConsoleColor Color) Get(MeanEnum mean)
{
    return mean switch
    {
        MeanEnum.Bike => ('B', ConsoleColor.Blue),
        MeanEnum.Bus => ('U', ConsoleColor.DarkGreen),
        MeanEnum.Car => ('C', ConsoleColor.Red),
        MeanEnum.Subway => ('S', ConsoleColor.Magenta),
        MeanEnum.Walk => ('W', ConsoleColor.DarkYellow),
        _ => throw new Exception("Unknown type")
    };
}

string[] months = GetMonthsNames();
int nameLength = months.Max(n => n.Length) + 2;
for (int i = 1; i <= 12; i++)
{
    string month = months[i - 1];
    Console.Write($"{month}:".PadRight(nameLength));
    for (int j = 1; j <= means[i - 1].Length; j++)
    {
        MeanEnum mean = means[i - 1][j - 1];
        (char character, ConsoleColor color) = Get(mean);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = color;
        Console.Write(character);
        Console.ResetColor();
        Console.Write(" ");
    }
    Console.WriteLine();
}

public enum MeanEnum { Car, Bus, Subway, Bike, Walk}