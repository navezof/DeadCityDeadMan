using UnityEngine;
using System.Collections;

public abstract class Action_Base : MonoBehaviour
{
	protected Character	owner;

	/** The cost in action point of this action */
	public int			actionCost;
	/** The cost in stamina of this action */
	public int			staminaCost;

	/** The range of this action */
	public int			range;
	/** The effect zone of this action */
	public int			effectZone;
	
	/** If true, the action need a target before activating */
	public bool			bNeedTarget;
	/** If true, the action can be activated */
	public bool			bReady;

	public abstract void Action_Start();
	public abstract void Action_Cancel();
	public abstract bool Action_Try(GameObject target);
	public abstract void Action(GameObject target);
	public abstract void Action_End(bool succes);

	public Character GetOwner() { return (owner); }
	public void SetOwner(Character _owner) { owner = _owner; }

	protected bool InRange(GameObject target)
	{
		Tile	targetTile;
		float distance;

		if (target.GetComponent<Character>() != null)
		{
			targetTile = target.GetComponent<Character>().GetTile().GetComponent<Tile>();;
		}
		else
		{
			targetTile = target.GetComponent<Tile>().GetComponent<Tile>();
		}
		distance = Mathf.Abs(targetTile.positionX - owner.GetX()) + Mathf.Abs(targetTile.positionY - owner.GetY());
		if (Mathf.RoundToInt(distance) > range)
			return (false);
		return (true);
	}

	protected bool HasStamina()
	{
		if (owner.Stamina() < staminaCost)
		{
			UI_Battle_Notification.notification.AddNotification("You don't have enough stamina!", Color.red);
			return (false);
		}
		return (true);
	}

	protected bool IsOnSameTeam(Character character)
	{
		if (character.faction == owner.faction)
			return (true);
		return (false);
	}

	protected void ActionCost()
	{
		owner.GetActionSystem().AP -= actionCost;
	}

	protected void SetColor(bool set, Tile.EColor color, int range)
	{
		Tile	tmpTile;
		int 	rangeY;
		
		rangeY = 0;
		for (int x = (int) owner.GetX() - range; x <= owner.GetX() + range; x++)
		{
			for (int y = (int) owner.GetY() - rangeY; y < owner.GetY() + rangeY + 1 ; y++)
			{
				if ((tmpTile = Grid.grid.GetTile(x, y)) != null)
				{
					if (set)
						tmpTile.SetColor(color);
					else
						tmpTile.RemoveColor(color);
				}
			}
			if (x < owner.GetX ())
				rangeY++;
			else
				rangeY--;
		}
	}
}
