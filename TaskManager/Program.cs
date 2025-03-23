using System;

namespace TaskManager
{
    internal class Program
    {
        static TaskContext context = new TaskContext();
        static bool onAction = true;

        static void Main(string[] args)
        {            
            Console.WriteLine($"Вас приветствует Менеджер Задач!");

            while (onAction)
            {
                Console.WriteLine($"Выберите действие: ");
                int actionId = GetChoice();

                if(actionId == 4)
                {
                    onAction = false;
                    break;
                }

                SetAction(actionId);
            }

            Console.WriteLine($"\nВсе ваши задачи и изменения сохранены." +
                $"\nБлагодарю за использование программы");
        }

        static int GetChoice()
        {
            bool isNum = false;
            int num;

            Console.WriteLine($"\n1: Новая задача." +
                $"\n2: Отметить задачу выполненной." +
                $"\n3: Показать все задачи." +
                $"\n4: Выйти.");

            do
            {
                isNum = int.TryParse(Console.ReadLine(), out num);
                if (isNum)
                {
                    if ((num >= 1) && (num <= 4))
                    {
                        return num;
                    }
                }
            } while (!isNum);
            return num;
        }

        static void SetAction (int _actionId)
        {
            switch (_actionId)
            {
                case 1:
                    Console.WriteLine($"Введите название задачи.");
                    string title = Console.ReadLine();
                    Console.WriteLine($"Введите описание задачи.");
                    string description = Console.ReadLine();
                    Console.WriteLine($"Введите дедлайн по задаче в формате \" dd-MM-yyyy\"");
                    DateTime deadline = DateTime.Parse(Console.ReadLine());

                    context.AddTask(new Task
                    {
                        Title = title,
                        Description = description,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        Deadline = deadline,
                        IsCompleted = false
                    });
                    Console.WriteLine($"Задача добавлена");
                    break;
                case 2:
                    Console.WriteLine($"Введите Id задачи.");
                    bool isNum = int.TryParse(Console.ReadLine(), out int id);
                    if (isNum)
                    {
                        context.IsCompletedMark(id);
                        Console.WriteLine($"Задача помечена как выполненная.");
                    }
                    break;
                case 3:
                    foreach (var task in context.GetAllTasks())
                    {
                        Console.WriteLine($"\n{task.Id}," +
                            $"\n{task.Title}," +
                            $"\n{task.UpdatedTime}," +
                            $"\n{task.Deadline}," +
                            $"\n{task.IsCompleted}");
                    }
                    break;
                
            }
        }
    }
}
