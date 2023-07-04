namespace Game.Stats
{
	/// <summary>
	/// Abstract Stat
	/// </summary>
	public abstract class AbstractStats<T>
	{
		protected T value = default;
		public T Value => value;

		/// <summary>
		/// Change value stat
		/// </summary>
		public abstract void SetValue(T newValue);
	}
}