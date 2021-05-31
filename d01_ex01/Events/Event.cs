using System;
using System.Collections.Generic;
using Tasks;

namespace Events
{
	abstract public record Event(string statusName);

	public class EventProcessor
    {
		public Tasks tasks;
		public struct Tasks
		{
			public string	title;
			public string	summary;
			public DateTime?	dueDate;
			public TasksType.Type? taskType;
			public TaskPriority.Priority? taskPriority;
			public string	stateTask;
		}

        private List<Tasks> _eventLogger = new List<Tasks>();


        public void ProcessEvent()
        {
            _eventLogger.Add(tasks);
        }

		public void	Print(Tasks task)
		{
			Console.WriteLine($"- {task.title}\n[{task.taskType.ToString()}][{task.stateTask}]");
			if (task.dueDate != null)
				Console.WriteLine($"Priority: {task.taskPriority.ToString()}, Due till {task.dueDate.Value.ToShortDateString()}\n{task.summary}");
			else
				Console.WriteLine($"Priority: {task.taskPriority.ToString()}\n{task.summary}");
		}

        public void PrintEventLogEntries()
        {
			if (_eventLogger.Count == 0)
			{
				Console.WriteLine("Список задач пока пуст.");
			}
			else
			{
				foreach (Tasks task in _eventLogger)
					Print(task);
			}
        }

		public Tasks GetLast()
		{
			return (_eventLogger[_eventLogger.Count - 1]);
		}

		public void GetByTitle(string title, string state, string command)
		{
			if (_eventLogger.Exists(x => x.title == title))
			{
				int index = _eventLogger.FindIndex(x => x.title == title);
				Tasks tmp = _eventLogger[index];
				if (_eventLogger[index].stateTask == "Done" && command == "wontdo")
				{
					Console.WriteLine("Завершенная не может стать Неактуальной");
					return ;
				}
				tmp.stateTask = state;
				_eventLogger[index] = tmp;
			}
			else
			{
				Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
			}
		}
    }
}