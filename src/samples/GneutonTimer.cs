namespace Gneuton
{
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
}