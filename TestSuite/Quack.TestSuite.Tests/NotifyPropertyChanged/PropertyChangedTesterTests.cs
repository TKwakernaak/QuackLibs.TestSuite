using Quack.TestSuite.NotifyPropertyChanged;
using Quack.TestSuite.Tests.NotifyPropertyChanged.Studs;

namespace Quack.TestSuite.Tests.NotifyPropertyChanged;

[TestClass]
public class PropertyChangedTesterTests
{
    public PropertyChangedTesterTests()
    {
            
    }


    [TestMethod]
    public void when_then()
    {
        var person = new PersonStud("1", "lastname", "mip@mep.com", new DateOnly(year: 2000, day: 01, month: 01));
        PropertyChangedTester<PersonStud>
                             .On(person)
                             .When(e => e.Email = "123@456.nl")
                             .AssertPropertyChangedNotRaised(e => e.Email);                              
    }
}
