using System;
using System.Collections.Generic;
using Tasks;

namespace d01_ex01
{
    class Program
    {
		private static Task	_task;
		private static bool TaskCommand(string command)
		{
			return (command == "add" || command == "list" || 
					command == "done" || command == "done" ||
					command == "wontdo" || command == "quit" || command == "q");
		}
        private static void Main(string[] args)
        {
			_task = new Task();
			while (true)
			{
				Console.Write("> ");
				string command = Console.ReadLine();
				if (TaskCommand(command))
				{
					_task.Command = command;
					_task.Commands();
				}
				else
				{
					Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
					Environment.Exit(-1);
				}
			}
        }
    }
}
