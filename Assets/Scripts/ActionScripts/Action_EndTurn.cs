using UnityEngine;
using System.Collections;

public class Action_EndTurn : Action_Base
{
	public override void Action_Start()
	{
		if (owner.GetActionSystem().action != null)
			owner.GetActionSystem().action.Action_Cancel();

		owner.GetActionSystem().action = this;

		bReady = true;
	}
	
	public override void Action_Cancel()
	{
		owner.GetActionSystem().action = null;
		bReady = false;
	}
	
	public override bool Action_Try(GameObject target)
	{
		return (true);
	}
	
	public override void Action(GameObject target)
	{
		Action_End(true);
	}
	
	public override void Action_End(bool success)
	{
		owner.GetActionSystem().EndAction();
		owner.EndTurn();
		bReady = false;
	}
}
