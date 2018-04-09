namespace Gneuton
{
	using System.Diagnostics;

    public class GneutonTimer
    {
        public GneutonTimer(IGneutonApplication application)
        {
            Debug.Assert(Stopwatch.IsHighResolution, "System does not support high-resolution performance counter");

            application.OnTick += OnTick;
        }

        public long StartTime { get; private set; }
        public long PreviousTime { get; private set; }
        public long DeltaTime { get; private set; }
		public long Frequency => Stopwatch.Frequency;

	    public void Start()
        {
            StartTime = Stopwatch.GetTimestamp(); 
        }

        public void Stop()
        {
        }

        private void OnTick()
        {
            var currentTime = Stopwatch.GetTimestamp();

	        DeltaTime = currentTime - PreviousTime; 
			PreviousTime = currentTime;
        }
    }
}