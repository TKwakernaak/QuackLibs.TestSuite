using System.ComponentModel;
using System.Linq.Expressions;

namespace Quack.TestSuite.NotifyPropertyChanged;

public class PropertyChangedTester<T> where T : INotifyPropertyChanged
{
	private readonly T _instance;

	private readonly PropertyChangedListener _listener;

	private PropertyChangedTester(T instance)
	{
		_instance = instance;
		_listener = new PropertyChangedListener();
		_instance.PropertyChanged += _listener.RegisterPropertyChange;
	}

	public static PropertyChangedTester<T> On(T instance) => new(instance);

	public PropertyChangedTester<T> When(Action<T> action)
	{
		action(_instance);
		return this;
	}

	public void AssertPropertyChangedRaised(Expression<Func<T, string>> expr)
	{
		if (expr.Body is not MemberExpression memberExpression)
			throw new ArgumentException($"The provided expression contains a {expr.GetType().Name} which is not supported. Only simple member accessors (properties) of an object are supported.");

		var propertyName = memberExpression.Member.Name;
		_listener.AssertPropertyChanged(propertyName);
	}

	public void AssertPropertyChangedNotRaised(Expression<Func<T, string>> expr)
	{
		if (expr.Body is not MemberExpression memberExpression)
			throw new ArgumentException($"The provided expression contains a {expr.GetType().Name} which is not supported. Only simple member accessors (properties) of an object are supported.");

		var propertyName = memberExpression.Member.Name;
		_listener.AssertPropertyNotChanged(propertyName);
	}

	public void AssertPropertyChangedInvoked(params string[] propertyNames)
	{
		foreach (var propertyName in propertyNames)
		{
			_listener.AssertPropertyChanged(propertyName);
		}
	}
}
