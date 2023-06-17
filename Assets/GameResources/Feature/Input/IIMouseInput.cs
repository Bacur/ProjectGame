namespace Game.Input
{
	using System;
	using UnityEngine;
	using UnityEngine.EventSystems;

	/// <summary>
	/// Interface events for input mouse
	/// </summary>
	public interface IIMouseInput
	{
		/// <summary>
		/// Event click on Environment
		/// </summary>
		event Action<Vector3> OnEnvironmentClick;

		/// <summary>
		/// Event click on InteractableObject
		/// </summary>
		event Action<IInteractableObject> OnInteractableObjectClick;

		/// <summary>
		/// Left click event on unit
		/// </summary>
		event Action<IUnit> OnUnitLeftClick;

		/// <summary>
		/// Right click event on unit
		/// </summary>
		event Action<IUnit> OnUnitRightClick;

		/// <summary>
		/// Left mouse click event
		/// </summary>
		event Action OnLeftClick;

		/// <summary>
		/// Right mouse click event
		/// </summary>
		event Action OnRightClick;
	}
}