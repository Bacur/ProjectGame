using Game.Stats;
using UnityEngine;

public abstract class AbstractInteractiveObject :MonoBehaviour, IInteractableObject
{
	public GeneralStatsTmeplate statsTmeplate = default;
	public GeneralStats GeneralStats = default;

	protected virtual void Awake() 
	{
		GeneralStats = new GeneralStats(statsTmeplate);
	}
}


