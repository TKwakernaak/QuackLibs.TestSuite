namespace Quack.TestSuite.NotifyPropertyChanged;
public static class AssertExtensions
{
	public static void AssertPropertyChanged(this PropertyChangedListener listener, string propertyName)
	{
		if (!listener.IsPropertyChangedRaised(propertyName))
		{
			throw new PropertyNotRaisedException($"property{propertyName} is not raised");
		}
	}

	public static void AssertPropertyNotChanged(this PropertyChangedListener listener, string propertyName)
	{	
		if (listener.IsPropertyChangedRaised(propertyName))
		{
			throw new PropertyNotRaisedException($"property{propertyName} is raised but was expected not to");
		}
	}

	private static bool IsPropertyChangedRaised(this PropertyChangedListener listener, string propertyName)
	{
		if (listener == null)
			throw new ArgumentNullException(nameof(listener));

		return listener.PropertiesChanged.Contains(propertyName);
	}
}
