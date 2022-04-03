using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    internal class Car : Position
    {
        public Car(Position StartPos)
        {
            this.x = StartPos.x;
            this.y = StartPos.y;
        }
        private List<Position> modelIndex = new List<Position>()//Строиться от 1 точки начальной позиции
        {
            new Position(){x = 0, y = 0},
            new Position(){x = -1, y = 1},
            new Position(){x = 0, y = 1},
            new Position(){x = 1, y = 1},
            new Position(){x = 0, y = 2},
            new Position(){x = -1, y = 3},
            new Position(){x = 0, y = 3},
            new Position(){x = 1, y = 3},
        };
        public ICollection<Position> GetModel => modelIndex;
        public bool Avaria(Car npc)
        {
            for(int i = 0; i < npc.modelIndex.Count; i++)
            {
                if(
                    (modelIndex[i].x + this.x) == (npc.modelIndex[i].x + npc.x) && 
                    (modelIndex[i].y + this.y) == (npc.modelIndex[i].y + npc.y)
                    )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
