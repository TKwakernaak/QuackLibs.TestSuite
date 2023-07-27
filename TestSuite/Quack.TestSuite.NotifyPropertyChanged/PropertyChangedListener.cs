using System.ComponentModel;

namespace Quack.TestSuite.NotifyPropertyChanged
{
	public class PropertyChangedListener 
	{
		private readonly List<string> propertiesChanged = new();

		public IReadOnlyList<string> PropertiesChanged => propertiesChanged;

		protected void RegisterPropertyChange(string propertyName)
		{
			propertiesChanged.Add(propertyName);		
		}

		public void RegisterPropertyChange(object? sender, PropertyChangedEventArgs e)
		{
			propertiesChanged?.Add(e?.PropertyName ?? "EmptyPropertyChanged");
		}
	}
}