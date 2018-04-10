namespace Gneuton
{
	using System.Drawing;
	using System.Windows.Forms;

	public sealed class GameForm : Form
	{
		public GneutonApplication GneutonApplication { get; }

		public GameForm(GneutonApplication gneutonApplication, string title = "Gneuton Game")
		{
			GneutonApplication = gneutonApplication;

			Text = title;
			Name = "Gneuton Game";

			FormBorderStyle = FormBorderStyle.None;
			SizeGripStyle = SizeGripStyle.Hide;
			ClientSize = new Size(1400, 900);
			StartPosition = FormStartPosition.CenterScreen;
			MinimumSize = new Size(200, 200);

			HookupListeners(gneutonApplication);
		}

		private void HookupListeners(GneutonApplication gneutonApplication)
		{
			KeyDown += (sender, e) =>
			{
				gneutonApplication.OnKeyDown(e.KeyCode);
			};
			KeyUp += (sender, e) =>
			{
				gneutonApplication.OnKeyUp(e.KeyCode);
			};

			MouseDown += (sender, e) =>
			{
				gneutonApplication.OnMouseDown(e.Button, new Point(e.X, e.Y));
			};
			MouseUp += (sender, e) =>
			{
				gneutonApplication.OnMouseUp(e.Button, new Point(e.X, e.Y));
			};
			MouseMove += (sender, e) =>
			{
				gneutonApplication.OnMouseMove(e.Button, new Point(e.X, e.Y));
			};

			Activated += (sender, e) =>
			{
				gneutonApplication.IsPaused = false;
			};

			Deactivate += (sender, e) =>
			{
				gneutonApplication.IsPaused = true;
			};

			HandleDestroyed += (sender, e) =>
			{
				gneutonApplication.IsRunning = false;
			};
		}

		public new void Update()
		{
		}
	}
}