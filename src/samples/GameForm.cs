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
		}

		public new void Update()
		{
		}
	}
}