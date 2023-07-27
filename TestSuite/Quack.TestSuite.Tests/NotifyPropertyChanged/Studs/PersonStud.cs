namespace Quack.TestSuite.Tests.NotifyPropertyChanged.Studs;

public class PersonStud : PropertyChangedBase
{
	public PersonStud(string firstName, string lastName, string email, DateOnly dateOfBirth)
	{
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		DateOfBirth = dateOfBirth;
	}

	private string _firstName;
	public string FirstName
	{
		get => _firstName;
		set
		{
			_firstName = value;
			OnPropertyChanged();
		}
	}

	private string _lastName;
	public string LastName
	{
		get => _lastName;
		set
		{
			_lastName = value;
			OnPropertyChanged();
		}
	}

	public string Email { get; set; }

	private DateOnly _dateOfBirth;
	public DateOnly DateOfBirth
	{
		get => _dateOfBirth;
		set
		{
			_dateOfBirth = value;
			OnPropertyChanged();
		}
	}
}

