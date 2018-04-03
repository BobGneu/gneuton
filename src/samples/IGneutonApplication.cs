namespace Gneuton
{
	using System;

	public interface IGneutonApplication {
		event Action OnTick;
	}
}