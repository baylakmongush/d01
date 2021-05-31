using System;
using System.IO;

namespace Models
{
    public class ExchangeSum
    {
		public Sum			sumStruct;
		public struct Sum
		{
			public string	id;
			public double	sum;
		}
        public ExchangeSum(string id, double sum)
		{
			sumStruct.id = id;
			sumStruct.sum = sum;
		}
    }
}
