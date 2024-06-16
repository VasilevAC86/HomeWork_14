using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HomeWork_14
{
    public class CommandFleet : Fleet
    {
        public string Name { get; set; }
        public string Rank { get; set; } // Звание
        public string Experience { get; set; } // Опыт
        public void Print() // Метод вывода в консоль всей информации от командующего
        {
            Console.WriteLine($"Командующий флотом.\nИмя: {Name}, звание: {Rank}, опыт: {Experience}\n\nФлот:");
            foreach (SpaceShip s in this.GetFleet()) 
                s.PrintShip();                
            Console.WriteLine("\nСписок миссий:");
            foreach (Mission m in this.GetMissions())
                m.Print();
        }
    }    
}
