using Quack.TestSuite.Tests.Equality.Studs;
using QuackLibs.TestSuite.Equality;

namespace Quack.TestSuite.Tests.Equality;

[TestClass]
public class EqualityTests
{
	[TestMethod]
	public void ValidateEquality()
	{
		var dutchLanguage1 = new Language("nl");
		var dutchLanguage2 = new Language("nl");
		var dutchLanguage3 = new Language("nl-NL");
		var englishLanguage = new Language("en");

		new EqualityTester<Language>(dutchLanguage1).EqualTo(dutchLanguage2)
													.NotEqualTo(dutchLanguage3, "case: culture nl-NL is not equal to nl")
													.NotEqualTo(englishLanguage, "case: culture english is not equal to culture nl")													
													.Assert();
	}
}
