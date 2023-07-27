using System.Reflection;

namespace Quack.TestSuite.Equality.Rules;

class MethodReturns<T, TResult> : ITestRule
{
	private MethodInfo Method { get; }
	private string MethodLabel { get; }
	private T TargetObject { get; }
	private TResult ExpectedResult { get; }
	private object[] MethodParameters { get; }
	private string TestCase { get; }

	private MethodReturns(MethodInfo method, string methodLabel, T target, TResult result, string testCase, params object[] parameters)
	{
		Method = method;
		MethodLabel = methodLabel;
		TargetObject = target;
		ExpectedResult = result;
		MethodParameters = parameters;
		TestCase = testCase;
	}

	public static MethodReturns<T, TResult> InstanceMethod(
		MethodInfo method, T target, TResult result,
		string testCase, params object[] parameters) =>
		new MethodReturns<T, TResult>(method, method.Name, target, result, testCase, parameters);

	public static MethodReturns<T, TResult> Operator(
		MethodInfo method, string operatorLabel, T obj1, T obj2, TResult result, string testCase) =>
		new MethodReturns<T, TResult>(method, operatorLabel, default, result, testCase, obj1, obj2);

	public IEnumerable<string> ErrorMessages()
	{
		IList<string> errors = new List<string>();

		try
		{
			TResult actualResult = (TResult)Method.Invoke(TargetObject, MethodParameters);
			if (!actualResult.Equals(ExpectedResult))
				errors.Add(
					$"{Method.GetSignature(MethodLabel)} returned {actualResult} when expecting {ExpectedResult} - {TestCase}");
		}
		catch (TargetInvocationException invocationExc)
		{
			errors.Add($"{Method.GetSignature()} failed - {invocationExc.Message}.");
		}
		catch (Exception exc)
		{
			errors.Add($"{Method.GetSignature()} failed - {exc.Message}.");
		}

		return errors;
	}
}