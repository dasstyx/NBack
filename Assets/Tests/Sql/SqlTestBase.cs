using NUnit.Framework;
using Zenject;

[TestFixture]
public abstract class SqlTestBase : ZenjectUnitTestFixture
{
    [SetUp]
    public void SetupTest()
    {
        sqlTestHelper = new SqlTestHelper(Container);
    }

    [TearDown]
    public void TearDown()
    {
        sqlTestHelper.TearDown();
    }

    protected SqlTestHelper sqlTestHelper;
}