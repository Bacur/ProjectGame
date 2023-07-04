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
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				IClickableObject clickable = GetMouseObjectClick(out Vector3 point);
				
				if (clickable is IInteractableObject interactableObject)
				{
					OnInteractableObjectClick?.Invoke(interactableObject);
				}
				else if (clickable is IUnit unit)
				{
					if (Input.GetMouseButtonDown(0))
					{
						OnUnitLeftClick?.Invoke(unit);
					}
					else if (Input.GetMouseButtonDown(1))
					{
						OnUnitRightClick?.Invoke(unit);
					}
				}
				else
				{
					OnEnvironmentClick?.Invoke(point);
				}

				if (Input.GetMouseButtonDown(0))
				{
					OnLeftClick?.Invoke();
				}
				else if (Input.GetMouseButtonDown(1))
				{
					OnRightClick?.Invoke();
				}
			}
		}

		private IClickableObject GetMouseObjectClick(out Vector3 ClcikPosition) 
		{
			RaycastHit hit;
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			ClcikPosition = hit.point;

			if (hit.collider.TryGetComponent(out IClickableObject clickable))
			{
				return clickable;
			}
			else if (hit.collider.transform.parent !=null && hit.collider.transform.parent.gameObject.TryGetComponent(out IClickableObject clickableParent))
			{
				return clickableParent;
			}
			else
			{
				return default;
			}
		}

	}
}