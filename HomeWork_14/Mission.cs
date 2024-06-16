using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_14
{
    public struct Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Aim { get; set; } // Цель
        public DateTime DateStart { get; set; } // Дата начала
        public void Print () 
        {
            Console.WriteLine(Id + ". " + Name + ", " + Aim + ", " + DateStart);
        }
    }
}
