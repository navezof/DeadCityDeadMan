using UnityEngine;
using System.Collections;

public class Action_CharacterInfo : Action_Base
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
		UI_Manager.UIManager.UI_Close("UI_Character_Info");
		owner.GetActionSystem().action = null;
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
		UI_Battle_Notification.notification.notifications.Clear();
		bReady = false;
	}

	public override bool Action_Try(GameObject target)
	{
		return (true);
	}

	public override void Action(GameObject target)
	{
		UI_Manager.UIManager.UI_Open("UI_Character_Info");
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_ONGUI;
	}

	public override void Action_End(bool succes)
	{
		UI_Manager.UIManager.UI_Close("UI_Character_Info");
		owner.GetActionSystem().action = null;
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
		UI_Battle_Notification.notification.notifications.Clear();
		bReady = false;
	}
}
