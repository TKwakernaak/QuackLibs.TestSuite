namespace Quack.TestSuite.Equality.Rules;

interface ITestRule
{
	IEnumerable<string> ErrorMessages();
}
