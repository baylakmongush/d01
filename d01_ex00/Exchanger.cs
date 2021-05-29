using System;
using System.IO;
using Models;

namespace d01_ex00
{
    public class Exchanger
    {
		private float			_sum;
		private string			_id;
		private string			_ratesDirectory;
		private ExchangeRate	_exchangeRate;
		private ExchangeSum		_exchangeSum;

        public Exchanger(string ratesDirectory, float sum, string id)
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

		public void ExchangeSumMethod(float sum, string id)
		{
			ExchangeSum = new ExchangeSum(id, sum);
		}

    }
}
