using System.Reflection;

namespace QuackLibs.TestSuite.Equality.Rules
{
	abstract class ImplementsMethod<T> : ITestRule
	{
		private string MethodName { get; }
		private string MethodLabel { get; }
		private Type[] ArgumentTypes { get; }

		private IEnumerable<MethodInfo> targetMethod;
		private Action DiscoverTargetMethod { get; set; }

		protected ImplementsMethod(string methodName, params Type[] argumentTypes)
			: this(methodName, methodName, argumentTypes)
		{
		}

		protected ImplementsMethod(string methodName, string methodLabel, params Type[] argumentTypes)
		{
			MethodName = methodName;
			MethodLabel = methodLabel;
			ArgumentTypes = argumentTypes;

			DiscoverTargetMethod = () =>
			{
				MethodInfo method = typeof(T).GetMethod(MethodName, ArgumentTypes);
				if (method == null)
					targetMethod = Enumerable.Empty<MethodInfo>();
				else
					targetMethod = new[] { method };

				DiscoverTargetMethod = () => { };
			};
		}

		public IEnumerable<MethodInfo> TryGetTargetMethod()
		{
			DiscoverTargetMethod();
			return targetMethod;
		}

		public IEnumerable<string> GetErrorMessages()
		{
			if (TryGetTargetMethod().All(method => method.DeclaringType != typeof(T)))
				yield return $"{typeof(T).Name} should {OverrideLabel} {MethodSignature}).";
		}

		private string OverrideLabel
		{
			get
			{
				if (TryGetTargetMethod().Any(m => m.GetBaseDefinition() != null))
					return "override";
				return "overload";
			}
		}
		private string MethodSignature =>
			$"{MethodLabel}({string.Join(", ", ArgumentTypes.Select(type => type.Name))}";
	}
}
