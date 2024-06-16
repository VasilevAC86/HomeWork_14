namespace HomeWork_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаём флот через командующего
            CommandFleet cap = new CommandFleet();
            cap.Name = "Вася";
            cap.Rank = "Генерал";
            cap.Experience = "Командирский опыт составляет 20 лет, 7 месяцев и 2 дня";
            cap.AddShip(new SpaceShip { Id = 1, Model = "Крейсей", Name = "Командирский флагман", Price = 10000000 });
            cap.AddShip(new SpaceShip { Id = 2, Model = "Линкор", Name = "Лидер", Price = 5000000 });
            cap.AddShip(new SpaceShip { Id = 3, Model = "Линкор", Name = "Быстрый", Price = 4750000 });
            cap.AddShip(new SpaceShip { Id = 4, Model = "Фрегат", Name = "Ловкий", Price = 800000 });
            cap.AddShip(new SpaceShip { Id = 5, Model = "Фрегат", Name = "Меткий", Price = 700000 });
            cap.AddShip(new SpaceShip { Id = 6, Model = "Фрегат", Name = "Живучий", Price = 1200000 });
            cap.AddShip(new SpaceShip { Id = 7, Model = "Фрегат", Name = "Тяжёлый", Price = 1800000 });
            cap.AddShip(new SpaceShip { Id = 8, Model = "Корвет", Name = "Обычный", Price = 80000 });
            cap.AddShip(new SpaceShip { Id = 9, Model = "Корвет", Name = "Рядовой", Price = 75000 });
            cap.AddShip(new SpaceShip { Id = 10, Model = "Корвет", Name = "Сержант", Price = 87000 });
            cap.AddShip(new SpaceShip { Id = 11, Model = "Корвет", Name = "Дежурный", Price = 60000 });
            cap.AddShip(new SpaceShip { Id = 12, Model = "Корвет", Name = "Старый", Price = 50000 });
            // Создаём миссию, общую для всех кораблей
            int counter = 0;
            foreach (var ship in cap.GetFleet()) 
                cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать планету Пандора", DateStart = new DateTime(2025, 02, 10), Id = 1 }, ++counter);
            // Создаём уникальные миссии для конкретный кораблей
            cap.Task(new Mission { Name = "Пандора", Aim = "Командовать боем", DateStart = new DateTime(2025, 02, 10), Id = 2 }, 1);
            cap.Task(new Mission { Name = "Пандора", Aim = "Уничтожить оборону дальнобойной артилерией", DateStart = new DateTime(2025, 02, 10), Id = 2 }, 2);
            cap.Task(new Mission { Name = "Пандора", Aim = "Уничтожить оборону дальнобойной артилерией", DateStart = new DateTime(2025, 02, 10), Id = 2 }, 3);
            cap.Task(new Mission { Name = "Пандора", Aim = "Защищать командирский флагман", DateStart = new DateTime(2025, 02, 10), Id = 3 }, 4);
            cap.Task(new Mission { Name = "Пандора", Aim = "Защищать командирский флагман", DateStart = new DateTime(2025, 02, 10), Id = 3 }, 5);
            cap.Task(new Mission { Name = "Пандора", Aim = "Прикрывать атакующие корветы", DateStart = new DateTime(2025, 02, 10), Id = 4 }, 6);
            cap.Task(new Mission { Name = "Пандора", Aim = "Прикрывать атакующие корветы", DateStart = new DateTime(2025, 02, 10), Id = 4 }, 7);
            cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать оборону Пандонры", DateStart = new DateTime(2025, 02, 10), Id = 5 }, 8);
            cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать оборону Пандонры", DateStart = new DateTime(2025, 02, 10), Id = 5 }, 9);
            cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать оборону Пандонры", DateStart = new DateTime(2025, 02, 10), Id = 5 }, 10);
            cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать оборону Пандонры", DateStart = new DateTime(2025, 02, 10), Id = 5 }, 11);
            cap.Task(new Mission { Name = "Пандора", Aim = "Атаковать оборону Пандонры", DateStart = new DateTime(2025, 02, 10), Id = 5 }, 12);
            cap.SaveToJSON("Fleet.json", cap.GetFleet()); // Сохраняем флот в файл "Fleet.json"
            cap.SaveToJSON("Missions.json", cap.GetMissions()); // Сохраняем миссии в файл "Missions.json"
            cap.Clean(); // Чистим списки флота и миссий для последующей проверки корректной десериализации из json
            foreach (SpaceShip el in cap.LoadFleetJSON("Fleet.json")) // Цикл десериализации флота
                cap.AddShip(el);
            foreach (Mission el in cap.LoadMissionsJSON("Missions.json")) // Цикл десериализации миссий
                cap.Task(el, 0);
            Console.WriteLine("Данные, десериализованные из json-файлов:\n");
            cap.Print();
            // Поиск кораблей по модели
            Console.Write("\nПоиск кораблей по модели.\nВведите модель корабля -> ");
            string model = Console.ReadLine();
            if (cap.FindByModel(model).Count() == 0)
                Console.WriteLine("Кораблей такой модели не найдено!");
            else
                foreach (SpaceShip s in cap.FindByModel(model))
                    s.PrintShip();
            // Поиск кораблей по диапазону стоимости
            Console.Write("\nПоиск кораблей по диапазону стоимости.\nВведите начало диапазона -> ");
            int start = Exc_Value(Console.ReadLine());
            Console.Write("Введите конец диапазона -> ");
            int end = Exc_Value(Console.ReadLine());
            if (end < start) // Если пользователь конец диапазона ввёл больше, чем начало
            {
               int tmp = end;
                end = start; 
                start = tmp;
            }
            if (cap.FindByRangeOfPrice(start, end).Count() == 0)
                Console.WriteLine("Кораблей в таком ценовом диапазоне не найдено!");
            else
                foreach (SpaceShip s in cap.FindByRangeOfPrice(start, end))
                    s.PrintShip();
            // Поиск миссий по Id корабля
            Console.Write("\nВведите id корабля -> ");
            int id = Exc_Value(Console.ReadLine());
            try
            {
                if (!cap.GetShipsMissions().ContainsKey(id))
                    throw new IdException("Корабля с таким id не существует!");
                Console.WriteLine($"Миссии корабля с id {id} слудующие:");
                foreach (Mission m in cap.missionsByShipId(id))
                    m.Print();
            }
            catch (IdException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static int Exc_Value(string message) // Метод обработки введённого пользователем значения типа decimal
        {
            int number = 0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (int.TryParse(message, out number)) { }
            if (!int.TryParse(message, out int value) || number < 1) // если введено не положительное целочисленное число, то 
            {
                while (!int.TryParse(message, out value) || number < 1)
                {
                    Console.Write("Введённое некорректное значение! Введите стоимость корабля ещё один раз -> ");
                    message = Console.ReadLine();
                    if (int.TryParse(message, out number)) { }
                }
            }
            return number;
        }
    }
}