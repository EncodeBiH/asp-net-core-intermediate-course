namespace EmployeeManager.Services;

public class PrimeNumberCheckerService
{
	public bool IsPrime(int number)
	{
		if(number < 1) return false;
		for (int i = 2; i < number; i++)
		{
			if (number % i == 0)
			{
				return false;
			}
		}

		return true;
	}
}
