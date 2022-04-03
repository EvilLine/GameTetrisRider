using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    internal class Drow : Position
    {
        ICollection<Car> cars { get; set; }
        public Drow(ICollection<Car> dataDrowModels)
        {
            cars = dataDrowModels;                     
        }
        public void DrowImage()
        {
            foreach (Car car in cars)
            {
                foreach (var model in car.GetModel)
                {
                    Console.SetCursorPosition(car.x + model.x, car.y + model.y);
                    Console.Write("@");
                }
            }
        }
        public void DrowDelete(Car car)
        {
            foreach (var model in car.GetModel)
            {
                Console.SetCursorPosition(car.x + model.x, car.y + model.y);
                Console.Write(" ");
            }
        }
    }    
}
