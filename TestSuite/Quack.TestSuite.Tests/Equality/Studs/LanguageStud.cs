using System.Globalization;

namespace Quack.TestSuite.Tests.Equality.Studs;

public sealed class Language : IEquatable<Language>
{
	public CultureInfo CultureInfo { get; set; }

	public string TwoLetterIsoLanguage => CultureInfo.TwoLetterISOLanguageName;

	public Language(CultureInfo cultureInfo)
	{
		CultureInfo = cultureInfo;
	}

	public Language(string cultureInfo)
	{
		CultureInfo = new CultureInfo(cultureInfo);
	}

	public static bool operator ==(Language language1, Language language2)
	{
		if (language1 is null && language2 is null)
		{
			return true;
		}

		return language1?.Equals(language2) ?? false;
	}

	public static bool operator !=(Language language1, Language language2) => !(language1 == language2);

	public override bool Equals(object? obj) => Equals(obj as Language);

	public bool Equals(Language? other)
	{
		if (other is null)
		{
			return false;
		}

		return this.CultureInfo.Equals(other.CultureInfo);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(CultureInfo);
	}
}
