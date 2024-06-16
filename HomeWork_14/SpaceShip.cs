using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_14
{
    public struct SpaceShip
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Price { get; set; } // Стоимость
        public void PrintShip()
        {
            Console.WriteLine(Id + ". " + Name + ", " + Model + ", " + Price + " рублей");
        }
    }
}
