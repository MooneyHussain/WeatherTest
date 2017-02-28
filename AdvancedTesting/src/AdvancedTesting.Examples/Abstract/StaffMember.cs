namespace AdvancedTesting.Examples.Abstract
{
    public abstract class StaffMember
    {
        public void ProvideDetails(string firstName, string surname)
        {
            var fullName = $"{surname}, {firstName}";
            DoSomethingAsLongAsItsAgile(fullName);
        }

        public abstract void DoSomethingAsLongAsItsAgile(string name);
    }

    public class Developer : StaffMember
    {
        public override void DoSomethingAsLongAsItsAgile(string name)
        {
            //do stuff 
        }
    }
}
