using System;

namespace AwsSimulator.Tests
{
	public class TestFixture
	{
		public void AlwaysFail()
		{
			throw new Exception("Test failed!");
		}

		public void AlwaysPass()
		{
			// Do nothing.
		}
	}
}
