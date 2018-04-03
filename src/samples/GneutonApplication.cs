namespace Gneuton
{
	using System;

	public class GneutonApplication : IDisposable, IGneutonApplication
	{
		public bool IsRunning { get; set; }
		public bool IsPaused { get; set; }
		public GneutonTimer timer { get; set; }

		public void Initialize()
		{
			timer = new GneutonTimer(this);
			IsRunning = true;
		}

		public event Action OnTick;

		public void HandleInput()
		{
			OnTick?.Invoke();
		}

		public void Update()
		{
		}

		public void Draw()
		{
			IsRunning = false;
		}

		public void Dispose()
		{
		}

		public void Synchronize()
		{
		}
	}
}