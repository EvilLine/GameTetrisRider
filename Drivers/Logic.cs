using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    internal class Logic
    {        
        public int TicNpc { get; set; }//Период движения НПС
        public int? cmd { get; set; }//Команды контроллера
        public bool game { get; set; }//Статус запуска игры
        public Score scorv { get; set; }//Система счетчика очков
        public Car user { get; set; }//Модель пользователя
        public Car[] npclib { get; set; }//Модели НПС
        public Drow Drow { get; set; }//Класс рисования
        public List<Car> cars { get; set; }//Общие объекты 
        public Logic()
        {

        }
        public void StartGame()
        {
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
                    foreach (var npc in npclib)
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
                        if (!user.Avaria(npc))
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
        }
    }
}
