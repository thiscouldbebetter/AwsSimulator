
namespace AwsSimulator.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			var testFixture = new TestFixture();
			testFixture.AlwaysPass();
			testFixture.AlwaysFail();
		}
	}
}
