namespace Game.Input
{
	using UnityEngine;
	using Zenject;

	public class MouseInputDebuger : MonoBehaviour
	{
		private IIMouseInput _mouseInput = default;

		[Inject]
		private void Construct(IIMouseInput mouseInput) 
		{
			_mouseInput = mouseInput;
			_mouseInput.OnInteractableObjectClick += _mouseInput_OnInteractableObjectClick;
		}

		private void OnDestroy()
		{
			_mouseInput.OnInteractableObjectClick -= _mouseInput_OnInteractableObjectClick;
		}

		private void _mouseInput_OnInteractableObjectClick(IInteractableObject obj)
		{
			if (obj is AbstractInteractiveObject abstractInteractive)
			{
			Debug.Log($"{obj.GetType()} = {abstractInteractive.GeneralStats.HitPoints.Value} : {abstractInteractive.GeneralStats.Armor.Value}");
			}

		}
	}
}