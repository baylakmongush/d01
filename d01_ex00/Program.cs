﻿using System;

namespace d01_ex00
{
    class Program
    {
		private static string		_ratesDirectory;
		private static string		_sum;
		private	static Exchanger	_exchanger;
		private static float		sumNum;
		private static string		id;
	
		static void	Init(string sum, string ratesDirectory)
		{
			_ratesDirectory = ratesDirectory;
			_sum = sum;
			ParseValues(out sumNum, out id);
			_exchanger = new Exchanger(_ratesDirectory, sumNum, id);
		}

		static private void	ParseValues(out float sumNum, out string id)
		{
			if (!float.TryParse(_sum.Split(' ')[0], out sumNum))
			{
				Console.WriteLine("Введите корректную сумму!");
				Environment.Exit(-1);
			}
			id = _sum.Split(' ')[1];
			if (id != "RUB" && id != "EUR" && id != "USD")
			{
				Console.WriteLine("Такой валюты не существует!");
				Environment.Exit(-1);	
			}
		}

		static void Printer()
		{
			Console.WriteLine($"Сумма в исходной валюте: { String.Format("{0:0.00}", sumNum) } {id}");
		}
	
        static void Main(string[] args)
        {
            if (args.Length == 2)
			{
				Init(args[0], args[1]);
				Printer();

			}
			else
				Console.WriteLine("Слишком много аргументов!");
        }
    }
}
