using Moq;
using NUnit.Framework;

namespace CSTournaments.Test
{
    public class UnitTestBase
    {
        protected MockRepository MockRepository { get; private set; }

        [SetUp]
        public void TestSetUp()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void TestTearDown()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Passed)
            {
                MockRepository.VerifyAll();
            }
        }
    }
}