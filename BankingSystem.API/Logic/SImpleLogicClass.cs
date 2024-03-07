namespace BankingSystem.API.Logic
{
	public static class SImpleLogicClass
	{
		public static int Divide(int x, int y)
		{
			if (y == 0)
			{
				return 0;
			}
			else
			{
				return x / y;
			}
		}
	}
}
