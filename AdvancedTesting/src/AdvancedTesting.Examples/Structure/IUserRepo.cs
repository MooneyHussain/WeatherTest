using System;

namespace AdvancedTesting.Examples.Structure
{
    public interface IUserRepo
    {
        User RetrieveUserFromId(Guid id);
    }
}
