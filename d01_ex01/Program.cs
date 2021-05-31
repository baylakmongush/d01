using System;
using Events;
using Tasks;

namespace d01_ex01
{
    class Program
    {
		private static Task	_task;
		private static EventProcessor _eventProcessor;
		private static bool TaskCommand(string command)
		{
			return (command == "add" || command == "list" || 
					command == "done" || command == "done" ||
					command == "wontdo" || command == "quit" || command == "q");
		}
        private static void Main(string[] args)
        {
			_task = new Task();
			_eventProcessor = new EventProcessor();
			while (true)
			{
				Console.Write("> ");
				string command = Console.ReadLine().Trim();
				if (TaskCommand(command))
				{
					_task.Command = command;
					_task.Commands(_eventProcessor);
				}
				else
				{
					Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				}
			}
        }
    }
}
