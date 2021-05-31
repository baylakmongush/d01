using System;


namespace Tasks
{
	public class Task
	{
		private string	_title = null;
		private string	_summary = null;
		private DateTime?	_dueDate = null;
		private TasksType.Type? _taskType = null;
		private TaskPriority.Priority? _taskPriority = null;
		
		private	string _command;

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

		private void	Add()
		{
			Console.WriteLine("Введите заголовок");
			Title = Console.ReadLine();
			if (Title == "")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				Quit();
			}
			Console.WriteLine("Введите описание");
			Summary = Console.ReadLine();
			Console.WriteLine("Введите срок");
			string data = Console.ReadLine();
			if (data != "")
			{
				bool success = DateTime.TryParse(data, out DateTime time);
				if (success)
					DueDate = time;
				else
				{
					Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
					Quit();
				}
			}
			Console.WriteLine("Введите тип");
			string type = Console.ReadLine();
			if (type != "Work" && type != "Study" && type != "Personal")
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				Quit();
			}
			else
			{
				Type = type == "Work" ? TasksType.Type.Work : null;
				Type = type == "Study" ? TasksType.Type.Study : null;
				Type = type == "Personal" ? TasksType.Type.Personal : null;
			}
			Console.WriteLine("Введите приоритет");
			string priority = Console.ReadLine();
			
			if (priority == "" || priority == "Low" || priority == "Normal" || priority == "High")
			{
				Priority = priority == "" ? TaskPriority.Priority.Normal : null;
				Priority = priority == "Low" ? TaskPriority.Priority.Low : null;
				Priority = priority == "Normal" ? TaskPriority.Priority.Normal : null;
				Priority = priority == "High" ? TaskPriority.Priority.High : null;
			}
			else
			{
				Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				Quit();
			}


		}

		private void	List()
		{

		}

		private void	Done()
		{

		}

		private void	WontDo()
		{

		}

		private void	Quit()
		{
			Environment.Exit(0);
		}

		public void Commands()
		{
			switch (Command)
			{
				case "add" :
							Add();
							break ;
				case "list" :
							List();
							break ;
				case "done" : 
							Done();
							break ;
				case "wontdo" :
							WontDo();
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