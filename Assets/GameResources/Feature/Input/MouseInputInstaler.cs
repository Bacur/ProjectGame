namespace Game.Input
{
	using UnityEngine;
	using Zenject;

	/// <summary>
	/// Installer mouseInput
	/// </summary>
	public class MouseInputInstaler : MonoInstaller 
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<MouseInput>().AsSingle().NonLazy();			
		}
	}
}