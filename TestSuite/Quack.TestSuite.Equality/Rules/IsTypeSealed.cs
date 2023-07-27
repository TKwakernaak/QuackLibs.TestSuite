namespace Quack.TestSuite.Equality.Rules;

class IsTypeSealed<T> : ITestRule
{
	public IEnumerable<string> ErrorMessages()
	{
		if (!typeof(T).IsSealed)
			yield return $"{typeof(T).Name} should be sealed.";
	}
}
