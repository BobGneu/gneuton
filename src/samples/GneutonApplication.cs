namespace Gneuton
{
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	public class GneutonApplication : IDisposable, IGneutonApplication
	{
		public bool IsRunning { get; set; }
		public bool IsPaused { get; set; }

		public GneutonTimer Timer { get; set; }
		public GameForm GameForm { get; set; }

		public void Initialize()
		{
			IsRunning = true;
			Timer = new GneutonTimer(this);

			InitializeMainWindow();
		}

		private void InitializeMainWindow()
		{
			GameForm = new GameForm(this);

			GameForm.KeyDown += (sender, e) => OnKeyDown(e.KeyCode);
			GameForm.KeyUp += (sender, e) => OnKeyUp(e.KeyCode);

			GameForm.MouseDown += (sender, e) => OnMouseDown(e.Button, new Point(e.X, e.Y));
			GameForm.MouseUp += (sender, e) => OnMouseUp(e.Button, new Point(e.X, e.Y));
			GameForm.MouseMove += (sender, e) => OnMouseMove(e.Button, new Point(e.X, e.Y));

			GameForm.Activated += (sender, e) =>
			{
				IsPaused = false;
				Timer.Start();
			};

			GameForm.Deactivate += (sender, e) =>
			{
				IsPaused = true;
				Timer.Stop();
			};

			GameForm.HandleDestroyed += (sender, e) => IsRunning = false;

			GameForm.Show();
			GameForm.Update();
		}

		private void OnMouseMove(MouseButtons eButton, Point point)
		{
		}

		private void OnMouseUp(MouseButtons eButton, Point point)
		{
			GameForm.Capture = false;
		}

		private void OnMouseDown(MouseButtons eButton, Point point)
		{
			GameForm.Capture = true;
		}

		protected virtual void OnKeyUp(Keys keyCode)
		{
			switch (keyCode)
			{
				case Keys.Escape:
					IsRunning = false;
					break;
			}
		}

		private void OnKeyDown(Keys eKeyCode)
		{
		}

		public event Action OnTick;

		public void HandleInput()
		{
		}

		public void Update()
		{
			Application.DoEvents();
			OnTick?.Invoke();

			GameForm.Update();
		}

		public void Draw()
		{
		}

		public void Dispose()
		{
		}
	}
}