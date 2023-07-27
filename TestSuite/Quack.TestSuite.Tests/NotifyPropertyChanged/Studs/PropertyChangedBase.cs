using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Quack.TestSuite.Tests.NotifyPropertyChanged.Studs;

public class PropertyChangedBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void RaisePropertyChanged(string propertyName) => OnPropertyChanged(propertyName);

	protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
