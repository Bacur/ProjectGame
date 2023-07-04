namespace Game.Stats
{
	using UnityEngine;
	/// <summary>
	/// Stat int value
	/// </summary>
	public class IntStats : AbstractStats<int>
	{
		public int _maxValue = default;
		public int _minValue = default;

		public IntStats(int maxValue, int minValue, int startValue)
		{
			_maxValue = maxValue;
			_minValue = minValue;
			value = startValue;
		}

		public override void SetValue(int newValue)
		{
			value = Mathf.Clamp(newValue, _minValue, _maxValue);
		}
	}
}