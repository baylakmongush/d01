using System;
using System.IO;

namespace Models
{
    public class ExchangeRate
	{
		public Rate rate;
		public struct Rate
		{
			public string	fromID;
			public float	fromExchangeCoeff;
			public string	toID;
			public float	toExchangeCoeff;
		}
    }
}
