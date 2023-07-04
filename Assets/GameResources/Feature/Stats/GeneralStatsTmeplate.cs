namespace Game.Stats
{
	using UnityEngine;

	[CreateAssetMenu(fileName = "General Stat Template", menuName = "Game/Stats/new General Stat Template")]
	public class GeneralStatsTmeplate : ScriptableObject
	{
		[SerializeField]
		private int _startHitPoints = 100;
		public int StartHitPoints => _startHitPoints;

		[SerializeField]
		private int _minHitPoints = 0;
		public int MinHitPoints => _minHitPoints;

		[SerializeField]
		private int _maxHitPoints = 100;
		public int MaxHitPoints => _maxHitPoints;

		[SerializeField]
		private int _startArmor = 10;
		public int StartArmor => _startArmor;

		[SerializeField]
		private int _minArmor = 0;
		public int MinArmor => _minArmor;

		[SerializeField]
		private int _maxArmor = 10;
		public int MaxArmor => _maxArmor;
	}
}