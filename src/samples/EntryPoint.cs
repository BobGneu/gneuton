namespace Gneuton
{
	using System;

	public static class EntryPoint
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static int Main(string[] args)
		{
			// TODO: Pass configuration parameters in here
			var application = Factory.CreateApplication();

			// Start timer
			application.Initialize();

			using (application)
			{
				while (application.IsRunning)
				{
					application.Update();
					application.Draw();
				}
			}

			return (int) ApplicationReturnCodes.AllsClear;
		}
	}
}
