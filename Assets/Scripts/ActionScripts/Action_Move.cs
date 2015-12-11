using UnityEngine;
using System.Collections;

public class Action_Move : Action_Base
{
	public override void Action_Start()
	{
		if (owner.GetActionSystem().action != null || (owner.GetActionSystem().action != null && owner.GetActionSystem().action != this))
			owner.GetActionSystem().action.Action_Cancel();
		owner.GetActionSystem().action = this;
		range = owner.GetMoveSystem().step;

		bReady = true;

		SetColor(true, Tile.EColor.COLOR_MOVE, owner.GetMoveSystem().step);
	}
	
	public override void Action_Cancel()
	{
		owner.GetActionSystem().action = null;
		SetColor(false, Tile.EColor.COLOR_MOVE, owner.GetMoveSystem().step);
		UI_Battle_Notification.notification.Clear();
		bReady = false;
	}
	
	public override bool Action_Try(GameObject target)
	{
		Tile	tile;
		float distance;

		if ((tile = target.GetComponent<Tile>()) == null)
			return (false);
		distance = Mathf.Abs(tile.positionX - owner.GetX()) + Mathf.Abs(tile.positionY - owner.GetY());
		if (Mathf.RoundToInt(distance) > owner.GetMoveSystem().step)
		{ 
			UI_Battle_Notification.notification.AddNotification("Not enough movement points.", Color.red);
			return (false);
		}
        if (!target.GetComponent<Tile>().IsWalkable())
        {
            UI_Battle_Notification.notification.AddNotification("There is already someone here.", Color.red);
            return (false);
        }
        /*
		if (target.GetComponent<Tile>().occupant != null && target.GetComponent<Tile>().occupant.tag != "Rune")
		{
			UI_Battle_Notification.notification.AddNotification("There is already someone here.", Color.red);
			return (false);
		}
         * */
		return (true);
	}
	
	public override void Action(GameObject target)
	{
		ActionCost();
		SetColor(false, Tile.EColor.COLOR_MOVE, owner.GetMoveSystem().step);
		owner.GetMoveSystem().Move(target.GetComponent<Tile>());
		Action_End(true);
	}
	
	public override void Action_End(bool success)
	{
		SetColor (false, Tile.EColor.COLOR_TARGET, range);
		UI_Battle_Notification.notification.Clear();
		owner.GetActionSystem().EndAction();
		bReady = false;
		return;
	}
}
