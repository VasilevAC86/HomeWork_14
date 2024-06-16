using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HomeWork_14
{
    public class Fleet:IFleetOperations
    {
        private List<SpaceShip> fleet_ = new List<SpaceShip>(); // Список кораблей
        private List<Mission> missions_ = new List<Mission>(); // Общий список миссий
        // Хранить миссии конкретного корабля будем списком в словаре, где ключ = Id корабля
        private Dictionary<int, List<Mission>> shipsMissions_ = new Dictionary<int, List<Mission>>();
        public void AddShip(SpaceShip obj)
        {
            fleet_.Add(obj);
        } 
        public void RemoveShip(int id)
        {
            fleet_.RemoveAll(x => x.Id == id); // Удаляем корабль из списка флота
            shipsMissions_.Remove(id); // Удаляем все миссии корябля
        }
        public void Task(Mission mission, int shipId) // Метод для назначения миссий
        {            
            if (!missions_.Contains(mission)) // Если миссии нет в общем списке миссий, то добавляем её
                missions_.Add(mission);           
            if (!shipsMissions_.ContainsKey(shipId)) // Если ещё нет списка миссий для конкретного корабля,
                shipsMissions_[shipId] = new List<Mission>(); // то инициализируем его
            if (shipId != 0)
                shipsMissions_[shipId].Add(mission); // Добавляем миссию конкретному кораблю            
        }
        public IReadOnlyList<SpaceShip> GetFleet() { return fleet_.AsReadOnly(); } // Доступ к флоту только для чтения
        public IReadOnlyList<Mission> GetMissions() {  return missions_.AsReadOnly(); } // Доступ к миссиям только для чтения
        // Доступ к словарю миссий кораблей только для чтения        
        public IReadOnlyDictionary<int, List<Mission>> GetShipsMissions() { return shipsMissions_.AsReadOnly(); }

        public void SaveToJSON<T>(string path, IReadOnlyList<T> obj) // Обобщённый метод сохранения данных в json-файлы
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, json);              
        }
        public IEnumerable<SpaceShip> LoadFleetJSON(string path) // Метод загрузки из json-файла флота
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<SpaceShip>>(json);
        }
        public IEnumerable<Mission> LoadMissionsJSON(string path) // Метод загрузки из json-файла миссий
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<IEnumerable<Mission>>(json);
        }
        public void Clean() // Метод очистки содержимого полей для последующего заполнения десериализацией из json  
        {
            fleet_.Clear();
            missions_.Clear();
        }
        public IEnumerable<SpaceShip> FindByModel(string model) // Метод для поиска кораблей по модели
        {
            return fleet_.Where(el => el.Model.ToLower() == model.ToLower()).ToList();
        }
        public IEnumerable<SpaceShip> FindByRangeOfPrice(decimal start, decimal end) // Метод для поиска кораблей по диапазону цены
        {
            return fleet_.Where(el => el.Price >= start && el.Price <= end).ToList();
        }
        public IReadOnlyList<Mission> missionsByShipId(int id) // Метод получения миссий конкретного корабля по его id
        {            
            return shipsMissions_[id].AsReadOnly();
        }
    }
}
