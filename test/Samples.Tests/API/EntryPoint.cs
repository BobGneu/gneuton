namespace Gneuton.Tests.API
{
	using NUnit.Framework;
	using Gneuton;

	[TestFixture]
	public class EntryPointTests
	{
		[Test]
		public void ShouldExist()
		{
			Assert.NotNull(typeof(EntryPoint));
		}

		[Test]
		public void ShouldHaveStaticMainMethod()
		{
			var type = typeof(EntryPoint);
			var method = type.GetMethod("Main");

			Assert.NotNull(method);

			Assert.AreEqual("Main", method.Name);
			Assert.AreEqual(typeof(int), method.ReturnType);

			Assert.IsTrue(method.IsStatic);

			var parameters = method.GetParameters();

			Assert.NotNull(parameters);
			Assert.AreEqual(1, parameters.Length);

			var parameter = parameters[0];

			Assert.AreEqual(typeof(string[]), parameter.ParameterType);
		}
	}
}
