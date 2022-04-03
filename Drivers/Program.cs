﻿using Drivers;

bool game = true;
int? cmd = null;
Console.CursorVisible = false;
for(int i = 0; i < 26; i++)
{
    Console.SetCursorPosition(0, i);
    Console.WriteLine("|");
    Console.SetCursorPosition(26, i);
    Console.WriteLine("|");
}

//Создаем машинку пользователя
var user = new Car(new Position() { x = 10, y = 10 });
var npclib = new Car[5];

//Добавляем хранилище объектов
var cars = new List<Car>();
//Добавляем сюда нашу машинку
cars.Add(user);
//Добавляем остальные объекты
for(int i = 0; i < 5; i++)
{
    npclib[i] = new Car(new Position() { x = new Random().Next(0, 25), y = 0 });
    cars.Add(npclib[i]);
}


//Система очков
var scorv = new Score();

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
                scorv.ScoreValue++;
            }
            if(!user.Avaria(npc))
            {
                Console.Clear();
                Console.WriteLine("GameOver");
                game = false;
                break;
            }
        }
        Console.SetCursorPosition(30, 20);
        Console.Write(scorv.Display);
        Drow.DrowImage();
        Thread.Sleep(10);       
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
