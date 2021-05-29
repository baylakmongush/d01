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
			public float	sum;
		}
        public ExchangeSum(string id, float sum)
		{
			sumStruct.id = id;
			sumStruct.sum = sum;
		}
    }
}
