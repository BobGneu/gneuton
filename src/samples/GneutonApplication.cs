namespace Gneuton
{
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	public class GneutonApplication : IDisposable, IGneutonApplication
	{
		public bool IsRunning { get; set; }
		public bool IsPaused { get; set; }

		public GameForm GameForm { get; set; }

		public void Initialize()
		{
			IsRunning = true;

			InitializeMainWindow();
		}

		private void InitializeMainWindow()
		{
			GameForm = new GameForm(this);;

			GameForm.Show();
			GameForm.Update();
		}

		public void OnMouseMove(MouseButtons eButton, Point point)
		{
		}

		public void OnMouseUp(MouseButtons eButton, Point point)
		{
			GameForm.Capture = false;
		}

		public void OnMouseDown(MouseButtons eButton, Point point)
		{
			GameForm.Capture = true;
		}

		public virtual void OnKeyUp(Keys keyCode)
		{
			switch (keyCode)
			{
				case Keys.Escape:
					IsRunning = false;
					break;
			}
		}

		public void OnKeyDown(Keys eKeyCode)
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