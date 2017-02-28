using Microsoft.Extensions.Logging;
using System;

namespace AdvancedTesting.Examples.Structure
{
    public class NameGenerator
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger _logger;

        public NameGenerator(IUserRepo userRepo, ILogger logger)
        {
            if (userRepo == null) throw new ArgumentNullException(nameof(userRepo));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _userRepo = userRepo;
            _logger = logger;
        }

        public string GenerateRapperName(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));

            var user = _userRepo.RetrieveUserFromId(id);
            return $"{user.FirstName} The Rapper";
        }
        
        public string GenerateNickname(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException(nameof(id));

            var user = _userRepo.RetrieveUserFromId(id);
            return $"{user.FirstName[0]}{user.Surname[0]}";
        }
    }
}
