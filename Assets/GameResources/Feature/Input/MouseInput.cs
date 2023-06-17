namespace Game.Input
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using Zenject;

	/// <summary>
	/// Mouse Input
	/// </summary>
	public class MouseInput : IIMouseInput, ITickable
	{
		public event Action<Vector3> OnEnvironmentClick = delegate { };
		public event Action<IInteractableObject> OnInteractableObjectClick = delegate { };
		public event Action<IUnit> OnUnitLeftClick = delegate { };
		public event Action<IUnit> OnUnitRightClick = delegate { };
		public event Action OnLeftClick = delegate { };
		public event Action OnRightClick = delegate { };

		[Inject]
		private List<ITickable> tickables = new List<ITickable>();

		public void Tick()
		{
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
			{
				IClickableObject[] clickables = GetMouseObjectClick(out Vector3 point);

				foreach (IClickableObject clickable in clickables)
				{
					if (clickable is IInteractableObject interactableObject)
					{
						OnInteractableObjectClick?.Invoke(interactableObject);
					}
					else if (clickable is IUnit unit)
					{
						if (Input.GetMouseButton(0))
						{
							OnUnitLeftClick?.Invoke(unit);
						}
						else if (Input.GetMouseButton(1))
						{
							OnUnitRightClick?.Invoke(unit);
						}
					}
					else
					{
						OnEnvironmentClick?.Invoke(point);
					}
				}
				if (Input.GetMouseButton(0))
				{
					OnLeftClick?.Invoke();
				}
				else if (Input.GetMouseButton(1))
				{
					OnRightClick?.Invoke();
				}
			}
		}

		private IClickableObject[] GetMouseObjectClick(out Vector3 ClcikPosition) 
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			ClcikPosition = hit.point;
			IClickableObject[] clickableObject = hit.collider.GetComponents<IClickableObject>();


			if (clickableObject.Length > 0)
			{
				return clickableObject;
			}
			else
			{
				return default;
			}
		}

	}
}