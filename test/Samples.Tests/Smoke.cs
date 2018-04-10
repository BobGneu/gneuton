namespace Samples.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class Smoke
	{
		[Test]
		public void ShouldBeEqual()
		{  
			Assert.AreEqual(1, 1, 0.01);
		}
	}
}
