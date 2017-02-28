using AdvancedTesting.Examples.Structure;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace AdvancedTesting.Examples.Tests.Structure
{
    public class NameGeneratorTests
    {
        private readonly Mock<IUserRepo> _userRepo;
        private readonly Mock<ILogger> _logger;
        private readonly NameGenerator _generator;

        public NameGeneratorTests()
        {
            _userRepo = new Mock<IUserRepo>();
            _logger = new Mock<ILogger>();
            _generator = new NameGenerator(_userRepo.Object, _logger.Object);            
        }

        public class Constructor : NameGeneratorTests
        {           
           //TODO 
        }

        public class GenerateRapperName : NameGeneratorTests
        {
            [Fact]
            public void GivenInvocationThenReturnRapperName()
            {
                var user = new User { FirstName = "Mooney", Id = Guid.NewGuid(), Surname = "Hussain" };
                _userRepo.Setup(repo => repo.RetrieveUserFromId(It.IsAny<Guid>())).Returns(user);

                var result = _generator.GenerateRapperName(user.Id);

                result.Should().Be("Mooney The Rapper");
            }
        }

        public class GenerateNickname : NameGeneratorTests
        {
            //TODO
        }
    }
}
