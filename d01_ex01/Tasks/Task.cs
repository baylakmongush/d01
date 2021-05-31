using System;
using Events;

namespace Tasks
{
	public class Task
	{
		private string	_title = null;
		private string	_summary = null;
		private DateTime?	_dueDate = null;
		private TasksType.Type? _taskType = null;
		private TaskPriority.Priority? _taskPriority = null;
		private string	_state;
		
		private	string _command;
		private TaskState _taskState = new TaskState();

		public string Command
		{
			set => _command = value;
			get => _command;
		}
		public string Title
		{
			set => _title = value;
			get => _title;
		}

		public string Summary
		{
			set => _summary = value;
			get => _summary;
		}

		public TasksType.Type? Type
		{
			set => _taskType = value;
			get => _taskType;
		}
		public TaskPriority.Priority? Priority
		{
			set => _taskPriority = value;
			get => _taskPriority;
		}

		public DateTime? DueDate
		{
			set => _dueDate = value;
			get => _dueDate;
		}

		public string State
		{
			set => _state = value;
			get => _state;
		}

		private void	Add(EventProcessor eventProcessor)
		{
			Console.WriteLine("Введите заголовок");
			Title = Console.ReadLine().Trim();
			if (Title == "")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			Console.WriteLine("Введите описание");
			Summary = Console.ReadLine().Trim();
			Console.WriteLine("Введите срок");
			string data = Console.ReadLine().Trim();
			if (data != "")
			{
				bool success = DateTime.TryParse(data, out DateTime time);
				if (success)
					DueDate = time;
				else
				{
					Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
					return ;
				}
			}
			else
			{
				DueDate = null;
			}
			Console.WriteLine("Введите тип");
			string type = Console.ReadLine().Trim();
			if (type != "Work" && type != "Study" && type != "Personal")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			else
			{
				Type = type == "Work" ? TasksType.Type.Work : Type;
				Type = type == "Study" ? TasksType.Type.Study : Type;
				Type = type == "Personal" ? TasksType.Type.Personal : Type;
			}
			Console.WriteLine("Введите приоритет");
			string priority = Console.ReadLine().Trim();
			
			if (priority == "" || priority == "Low" || priority == "Normal" || priority == "High")
			{
				Priority = priority == "" ? TaskPriority.Priority.Normal : Priority;
				Priority = priority == "Low" ? TaskPriority.Priority.Low : Priority;
				Priority = priority == "Normal" ? TaskPriority.Priority.Normal : Priority;
				Priority = priority == "High" ? TaskPriority.Priority.High : Priority;
			}
			else
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			State = _taskState.New();
			eventProcessor.tasks.title = Title;
			eventProcessor.tasks.summary = Summary;
			eventProcessor.tasks.dueDate = DueDate;
			eventProcessor.tasks.taskType = Type;
			eventProcessor.tasks.taskPriority = Priority;
			eventProcessor.tasks.stateTask = State;
			eventProcessor.ProcessEvent();
			eventProcessor.Print(eventProcessor.GetLast());
		}

		private void	List(EventProcessor eventProcessor)
		{
			eventProcessor.PrintEventLogEntries();
		}

		private void	Done(EventProcessor eventProcessor)
		{
			State = _taskState.Done();
			string title = Console.ReadLine();
			if (title == "")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			eventProcessor.GetByTitle(title, State, Command);
		}

		private void	WontDo(EventProcessor eventProcessor)
		{
			State = _taskState.WontDo();
			string title = Console.ReadLine();
			if (title == "")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return ;
			}
			eventProcessor.GetByTitle(title, State, Command);
		}

		private void	Quit()
		{
			Environment.Exit(0);
		}

		public void Commands(EventProcessor eventProcessor)
		{
			switch (Command)
			{
				case "add" :
							Add(eventProcessor);
							break ;
				case "list" :
							List(eventProcessor);
							break ;
				case "done" : 
							Done(eventProcessor);
							break ;
				case "wontdo" :
							WontDo(eventProcessor);
							break ;
				case "quit" :
							Quit();
							break ;
				case "q" :
							Quit();
							break ;
			}
		}
	}
}