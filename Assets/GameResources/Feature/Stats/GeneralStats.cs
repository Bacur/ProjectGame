namespace Game.Stats
{
	using UnityEngine;
	/// <summary>
	/// Base stats all objects
	/// </summary>
	public class GeneralStats
	{
		private IntStats _hitPoints = default;
		/// <summary>
		/// Hit points stat
		/// </summary>
		public IntStats HitPoints => _hitPoints;

		private IntStats _armor = default;
		/// <summary>
		/// Armor points stat
		/// </summary>
		public IntStats Armor => _armor;

		public GeneralStats(int startHitPoints, int startArmor, int minHitPoints = 0, int maxHitPoints = 100, int minArmor = 0, int maxArmor = 10)
		{
			_hitPoints = new IntStats(startHitPoints, minHitPoints, maxHitPoints);
			_armor = new IntStats(startArmor, minArmor, maxArmor);
		}

		public GeneralStats(GeneralStatsTmeplate statsTmeplate) 
		{
			_hitPoints = new IntStats(statsTmeplate.StartHitPoints, statsTmeplate.MinHitPoints, statsTmeplate.MaxHitPoints);
			_armor = new IntStats(statsTmeplate.StartArmor, statsTmeplate.MinArmor, statsTmeplate.MaxArmor);
		}

		public void ChangeHitPointsByArmor(int addValue)
		{
			if (addValue > 0)
			{
				_hitPoints.SetValue(_hitPoints.Value + addValue);
			}
			else
			{
				addValue = Mathf.Clamp(addValue + _armor.Value, 0, int.MaxValue);
				_hitPoints.SetValue(_hitPoints.Value + addValue);
			}
		}
	}
}