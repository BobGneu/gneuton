namespace Gneuton
{
	using System;

	static class EntryPoint
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main()
		{
			// TODO: Pass configuration parameters in here
			var application = Gneuton.Factory.CreateApplication();

			// Start timer
			application.Initialize();

			using (application)
			{
				while (application.IsRunning)
				{
					application.Synchronize();
				}
			}

			return (int) ApplicationReturnCodes.AllsClear;
		}
	}
}
