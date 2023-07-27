namespace Quack.TestSuite.NotifyPropertyChanged;

[System.Serializable]
public class PropertyNotRaisedException : Exception
{
	public PropertyNotRaisedException() { }
	public PropertyNotRaisedException(string message) : base(message) { }
	public PropertyNotRaisedException(string message, Exception inner) : base(message, inner) { }
	protected PropertyNotRaisedException(
	  System.Runtime.Serialization.SerializationInfo info,
	  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

