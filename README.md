# TaskManagerPro

**Console-based Task Management Application in C#**

TaskManagerPro is a simple but feature-rich console application that allows users to create, complete, and remove tasks. All data is stored persistently in a JSON file, and all operations can be logged in a log.txt file.

---

## Features

- Add new tasks with a title and creation date
- Mark tasks as completed
- Remove tasks by ID
- Display all tasks with ID, title, status, and creation date
- Persistent data storage in `tasks.json`
- Simple logging of operations in `log.txt`
- Error handling and validation (e.g., empty title, non-existent ID)

---

## Technologies

- C# .NET 6/7
- JSON for data storage
- Console application
- Repository + Service design pattern
- Error handling and basic logging

---

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/YourUsername/TaskManagerPro.git
Open the project in Visual Studio

Set Program.cs as the Startup Project

Run the project (F5)

Use the console menu:

1 – Show all tasks

2 – Add task

3 – Complete task

4 – Remove task

5 – Exit

Project Structure
powershell
Skopiuj kod
TaskManagerPro
│
├─ Core
│  ├─ Models
│  │   └─ TaskItem.cs
│  └─ Enums
│      └─ TaskStatus.cs
│
├─ Data
│  └─ JsonTaskRepository.cs
│
├─ Services
│  ├─ ITaskService.cs
│  └─ TaskService.cs
│
├─ Logging
│  └─ Logger.cs
│
└─ Program.cs
How It Works
Program.cs – handles user interaction and displays the console menu.

TaskService – business logic: adding, completing, and removing tasks.

JsonTaskRepository – handles persistent storage in tasks.json.

Logger – logs events in log.txt (e.g., adding or completing tasks).

Example Console Output
markdown
Skopiuj kod
=== Task Manager Pro ===
1. Show all tasks
2. Add task
3. Complete task
4. Remove task
5. Exit
Choose an option: 2
Enter task title: Learn C#
Task added.
