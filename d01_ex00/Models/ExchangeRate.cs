using System;
using System.IO;

namespace Models
{
    public class ExchangeRate
	{
		public Rate rate;
		public struct Rate
		{
			public string	toID;
			public double	exchangeCoeff;
		}
    }
}
