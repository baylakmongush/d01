using System.Collections.Generic;
using System.IO;
using System;
using Models;

namespace d01_ex00
{
    public class Exchanger
    {
		private double			_sum;
		private string			_id;
		private string			_ratesDirectory;
		private ExchangeRate	_exchangeRate;
		private ExchangeSum		_exchangeSum;

        public Exchanger(string ratesDirectory, double sum, string id)
		{
			_ratesDirectory = ratesDirectory;
			_sum = sum;
			_id = id;
			ExchangeRateMethod();
			ExchangeSumMethod(sum, id);
		}


		public ExchangeRate ExchangeRate
		{
			get => _exchangeRate;
			set => _exchangeRate = value;
		}

		public ExchangeSum ExchangeSum
		{
			get => _exchangeSum;
			set => _exchangeSum = value;
		}
	
		public void	ExchangeRateMethod()
		{
			ExchangeRate = new ExchangeRate();
		}

		public void ExchangeSumMethod(double sum, string id)
		{
			ExchangeSum = new ExchangeSum(id, sum);
		}

		public Dictionary<string, double>	Parse()
		{
			Dictionary<string, double>	results = new Dictionary<string, double>();
			string fullPath = _ratesDirectory + '/' +_id + ".txt";
			if (File.Exists(fullPath))
			{
				using(StreamReader file = new StreamReader(fullPath))
				{  
					string ln;  
				
					while ((ln = file.ReadLine()) != null)
					{  
						ExchangeRate.rate.toID = ln.Split(':')[0];
						if (!double.TryParse(ln.Split(':')[1], out ExchangeRate.rate.exchangeCoeff))
						{
							Console.WriteLine("Некорректный коэффициент!");
							Environment.Exit(-1);
						}
						results.Add(ExchangeRate.rate.toID, ExchangeRate.rate.exchangeCoeff * _sum);
					}  
					file.Close();
				}
			}
			else
			{
				Console.WriteLine("Введите корректный путь до папки!");
				Environment.Exit(-1);
			}
			return (results);
		}

    }
}
