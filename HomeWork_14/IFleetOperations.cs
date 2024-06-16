using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_14
{
    public interface IFleetOperations
    {
        void AddShip(SpaceShip obj); // Добавление корабля
        void RemoveShip(int id); // Удаление корабля
        void Task(Mission mission, int shipId); // Назначение миссии
    }
}
