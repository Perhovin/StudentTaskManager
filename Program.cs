const int MaxTasks = 10;

List<string> tasks = new List<string>();
tasks.Add("Review C# variables");
tasks.Add("Practice loops");
tasks.Add("Create a Console application");

bool running = true;

Console.WriteLine("Student Task Manager");
Console.WriteLine("=====================");

while (running)
{
    ShowMenu(); 
    
    Console.Write("Choose an option: ");
    int option = int.Parse(Console.ReadLine());

    switch (option) 
    {
        case 1:
            AddTask(tasks);
            break;
        case 2:
            ShowTasks(tasks);
            break;
        case 3:
            RemoveTask(tasks); 
            break;
        case 4:
            ShowTaskCount(tasks); 
            break;
        case 0:
            Console.WriteLine("Exiting the program...");
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

void ShowMenu() 
{
    Console.WriteLine();
    Console.WriteLine("1. Add task");        //[cite: 17]
    Console.WriteLine("2. View tasks");      //[cite: 17]
    Console.WriteLine("3. Remove task");     //[cite: 17]
    Console.WriteLine("4. Show task count"); //[cite: 17]
    Console.WriteLine("0. Exit");            //[cite: 17]
}

void AddTask(List<string> tasks)
{
    if (tasks.Count >= MaxTasks)
    {
        Console.WriteLine("Maximum number of tasks reached.");
        return;
    }

    Console.Write("Enter task: ");
    string task = Console.ReadLine();

    Console.WriteLine("Select priority (1: Low, 2: Medium, 3: High): ");
    int prioChoice = int.Parse(Console.ReadLine());
    
    TaskPriority selectedPriority = TaskPriority.Low;
    switch (prioChoice)
    {
        case 1: selectedPriority = TaskPriority.Low; break;
        case 2: selectedPriority = TaskPriority.Medium; break;
        case 3: selectedPriority = TaskPriority.High; break;
        default: Console.WriteLine("Invalid choice. Defaulting to Low."); break;
    }

    tasks.Add($"[{selectedPriority}] {task}");
    Console.WriteLine("Task added successfully!");
}

void ShowTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}

void RemoveTask(List<string> tasks)
{
    Console.Write("Task to remove (number): ");
    int taskNumber = int.Parse(Console.ReadLine());
    tasks.RemoveAt(taskNumber - 1);
}

void ShowTaskCount(List<string> tasks)
{
    int currentCount = tasks.Count;
    int remaining = MaxTasks - currentCount; 

    // Вывод статистики в точном соответствии с заданием[cite: 17]
    Console.WriteLine($"You currently have {currentCount} tasks.");  //[cite: 17]
    Console.WriteLine($"Maximum allowed: {MaxTasks}");               //[cite: 17]
    Console.WriteLine($"Remaining capacity: {remaining}");           //[cite: 17]
}

enum TaskPriority
{
    Low,
    Medium,
    High
}