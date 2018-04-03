namespace Gneuton
{
	using System;

	public class GneutonTimer
	{
		public GneutonTimer(IGneutonApplication application)
		{
			application.OnTick += this.OnTick;
		}

		private void OnTick()
		{
		}
	}

	public interface IGneutonApplication {
		event Action OnTick;
	}
}