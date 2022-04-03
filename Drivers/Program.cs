using Drivers;

bool game = true;
int? cmd = null;
Console.CursorVisible = false;

//Создаем машинку пользователя
var user = new Car(new Position() { x = 10, y = 10 });
var npclib = new Car[5];

//Добавляем хранилище объектов
var cars = new List<Car>();
cars.Add(user);
for(int i = 0; i < 5; i++)
{
    npclib[i] = new Car(new Position() { x = new Random().Next(0, 25), y = 0 });
    cars.Add(npclib[i]);
}




//Включаем службу рисования
var Drow = new Drow(cars);
//Запускаем все хозяйство
int TicNpc = 1000;
Task.Run(() =>
{
    while (game)
    {
        switch (cmd)
        {
            case 0:
                Drow.DrowDelete(user);
                user.y--;              
                break;
            case 1:
                Drow.DrowDelete(user);
                user.y++;               
                break;
            case 2:
                Drow.DrowDelete(user);
                user.x--;               
                break;
            case 3:
                Drow.DrowDelete(user);
                user.x++;
                break;
            default:
                break;
        }
        cmd = null;
        foreach(var npc in npclib)
        {
            if (TicNpc > 0)
            {
                TicNpc = TicNpc - new Random().Next(10, 100);
            }
            else
            {
                if (npc.y < 20)
                {
                    Drow.DrowDelete(npc);
                    npc.y++;
                }
                else
                {
                    Drow.DrowDelete(npc);
                    npc.x = new Random().Next(3, 25);
                    npc.y = 0;
                }
                TicNpc = 1000;
            }
            if(!user.Avaria(npc))
            {
                Console.WriteLine("GameOver");
                game = false;
                break;
            }
        }
       
        Drow.DrowImage();
        Thread.Sleep(10);       
    }
});
/// <summary>
/// Служба других машинок как объектов
/// </summary>
Task.Run(() =>
{
    while(true)
    {
        
        Thread.Sleep(1000);
    }
});
/// <summary>
/// Контроль клавиш
/// </summary>
while(true)
{
    var consoleKey = Console.ReadKey();
    switch (consoleKey.Key)
    {
        case ConsoleKey.UpArrow:
            cmd = 0;
            break;
        case ConsoleKey.DownArrow:
            cmd = 1;
            break;
        case ConsoleKey.LeftArrow:
            cmd = 2;
            break;
        case ConsoleKey.RightArrow:
            cmd = 3;
            break;
        default:
            cmd = null;
            break;
    }
}
