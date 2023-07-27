using Quack.TestSuite.Equality;
using Quack.TestSuite.Equality.Rules;

namespace QuackLibs.TestSuite.Equality;

public class EqualityTester<T>
{
	private T TargetObject { get; }
	private List<ITestRule> Rules { get; } = new List<ITestRule>();
	private TypeAnalysis<T> Analysis { get; }

	public EqualityTester(T targetObject)
	{
		TargetObject = targetObject;
		Analysis = TypeAnalysis<T>.Analyze();

		Rules.AddRange(Analysis.TypeLevelRules);

		if (!typeof(T).IsValueType)
		{
			Rules.AddRange(Analysis.GetNotEqualRules(TargetObject, default, "inequality to null"));
			Rules.AddRange(Analysis.GetEqualityOfTwoNulls());
		}
	}

	public EqualityTester<T> EqualTo(T obj)
	{
		Rules.AddRange(Analysis.GetEqualToRules(TargetObject, obj));
		return this;
	}

	public EqualityTester<T> NotEqualTo(T obj, string testCase)
	{
		Rules.AddRange(Analysis.GetNotEqualRules(TargetObject, obj, testCase));
		return this;
	}

	public void Assert()
	{
		List<string> errorMessages =
			Rules.SelectMany(rule => rule.ErrorMessages()).ToList();

		if (errorMessages.Any())
		{
			string message =
				"There were errors testing equality logic:\n" +
				string.Join(Environment.NewLine, errorMessages.ToArray());

			throw new ValueSemanticException(message);
		}
	}
}
