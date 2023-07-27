using System.Reflection;

namespace QuackLibs.TestSuite.Equality.Rules
{
	class GetHashCodeEqualReturns<T> : ITestRule
	{
		private MethodInfo Method { get; }
		private T TargetInstance { get; }
		private T OtherObject { get; }

		public GetHashCodeEqualReturns(MethodInfo method, T obj1, T obj2)
		{
			Method = method;
			TargetInstance = obj1;
			OtherObject = obj2;
		}

		public IEnumerable<string> GetErrorMessages()
		{
			IList<string> errors = new List<string>();

			try
			{
				int hash1 = (int)Method.Invoke(TargetInstance, new object[0]);
				int hash2 = (int)Method.Invoke(OtherObject, new object[0]);

				if (hash1 != hash2)
					errors.Add($"{Method.GetSignature()} returned distinct values on equal objects.");
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
}
