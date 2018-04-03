namespace Gneuton
{
	public class GneutonTimer
	{
		public GneutonTimer(GneutonApplication gneutonApplication)
		{
			gneutonApplication.OnTick += this.OnTick;
		}

		private void OnTick()
		{
		}
	}
}