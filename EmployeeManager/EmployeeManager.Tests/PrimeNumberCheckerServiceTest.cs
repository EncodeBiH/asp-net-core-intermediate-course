using EmployeeManager.Services;

namespace EmployeeManager.Tests;

public class PrimeNumberCheckerServiceTest
{
	private PrimeNumberCheckerService primeNumberService;
	public PrimeNumberCheckerServiceTest()
	{
		primeNumberService = new PrimeNumberCheckerService();
	}


	[Theory]
	[InlineData(4, false)]
	[InlineData(5, true)]
	[InlineData(26, false)]
	[InlineData(36, true)]
	public void Test_If_Number_Is_Prime(int value, bool expectedPrime)
	{
		bool isPrime = primeNumberService.IsPrime(value);

		Assert.Equal(expectedPrime, isPrime);
	}

	//[Theory]
	//[InlineData(3)]
	//[InlineData(5)]
	//[InlineData(37)]
	//public void Test_If_Number_Is_Prime(int value)
	//{
	//	bool isPrime = primeNumberService.IsPrime(value);

	//	Assert.True(isPrime);
	//}
}