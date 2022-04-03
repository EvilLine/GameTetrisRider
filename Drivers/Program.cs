using Drivers;


Console.CursorVisible = false;
Console.WriteLine("Нажмите любую клавишу чтобы начать игру");
Console.ReadLine();
var logic = new Logic();
logic.game = true;
logic.user = new Car(new Position() { x = 10, y = 10 });
for (int i = 0; i < 26; i++)
{
    Console.SetCursorPosition(0, i);
    Console.WriteLine("|");
    Console.SetCursorPosition(26, i);
    Console.WriteLine("|");
}
logic.npclib = new Car[5];
logic.cars = new List<Car>();
logic.cars.Add(logic.user);
for(int i = 0; i < 5; i++)
{
    logic.npclib[i] = new Car(new Position() { x = new Random().Next(3, 25), y = 0 });
    logic.cars.Add(logic.npclib[i]);
}
logic.scorv = new Score();
logic.Drow = new Drow(logic.cars);
logic.TicNpc = 1000;
logic.StartGame();
/// <summary>
/// Контроль клавиш
/// </summary>
while(true)
{
    var consoleKey = Console.ReadKey();
    switch (consoleKey.Key)
    {
        case ConsoleKey.UpArrow:
            logic.cmd = 0;
            break;
        case ConsoleKey.DownArrow:
            logic.cmd = 1;
            break;
        case ConsoleKey.LeftArrow:
            logic.cmd = 2;
            break;
        case ConsoleKey.RightArrow:
            logic.cmd = 3;
            break;
        default:
            logic.cmd = null;
            break;
    }
}
