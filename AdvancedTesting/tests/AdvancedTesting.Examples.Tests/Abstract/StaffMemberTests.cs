using AdvancedTesting.Examples.Abstract;
using FluentAssertions;
using Moq;
using Xunit;

namespace AdvancedTesting.Examples.Tests.Abstract
{
    public class StaffMemberTests
    {
        private TestStaffMember _target; 

        public StaffMemberTests()
        {
            _target = new TestStaffMember();
        }   
             
        [Fact]
        public void GivenInvocationThenSetupNameViaDerivedClass()
        {
            _target.ProvideDetails("Mooney", "Hussain");

            var result = _target.FullName;

            result.Should().Be("Hussain, Mooney");
        }

        [Fact]
        public void GivenInvocationThenSetupNameViaMoq()
        {
            var mock = new Mock<StaffMember>();
            var staffMember = mock.Object;

            staffMember.ProvideDetails("Mooney", "Hussain");
            mock.Verify(m => m.DoSomethingAsLongAsItsAgile("Hussain, Mooney"));
        }
    }

    public class TestStaffMember : StaffMember
    {
        public string FullName { get; private set; } //this is to just expose a public property that I can assert

        public override void DoSomethingAsLongAsItsAgile(string name)
        {
            FullName = name;
        }
    }
}
