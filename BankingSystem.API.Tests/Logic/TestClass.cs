using BankingSystem.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.API.Tests.Logic
{
	public class TestClass
	{
		[Fact]
		public void Test()
		{
			int x = 10;
			int y = 2;

			var result = SImpleLogicClass.Divide(x, y);

			Assert.Equal(5, result);
		}
	}
}
