using System.Collections.Generic;

namespace QuackLibs.TestSuite.Equality.Rules
{
	interface ITestRule
	{
		IEnumerable<string> GetErrorMessages();
	}
}
