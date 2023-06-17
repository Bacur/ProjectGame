using Zenject;
/// <summary>
/// Any unit in game
/// </summary>
public interface IUnit : IClickableObject
{

}


public class PlayerMove : ITickable
{
	public void Tick()
	{
		throw new System.NotImplementedException();
	}
}
