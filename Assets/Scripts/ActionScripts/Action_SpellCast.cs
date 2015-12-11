using UnityEngine;
using System.Collections;

public class Action_SpellCast : Action_Base
{
	/** The current spell */
	public SpellCast	spell;

	/** The selected spec */
	public int		spec;

	/** If true the spell can only be cast on an empty Tile */
	public bool		bNeedEmptyTile;

	public override void Action_Start()
	{
		if (owner.GetActionSystem().action != null)
			owner.GetActionSystem().action.Action_Cancel();
		owner.GetActionSystem().action = this;

		owner.GetActionSystem().spec = owner.GetSpecManager().equippedSpecs[spec].GetComponent<Spec>();
        
		UI_Manager.UIManager.UI_Open("UI_Battle_Spell");
	}

	public override void Action_Cancel()
	{
		owner.GetActionSystem().action = null;
		SetColor(false, Tile.EColor.COLOR_TARGET, range);
		UI_Battle_Notification.notification.Clear();
		UI_Manager.UIManager.UI_Close("UI_Battle_Spell");
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;
		bReady = false;
	}

	public override bool Action_Try(GameObject target)
	{
		Tile targetScript;

		if (bNeedEmptyTile && ((targetScript = target.GetComponent<Tile>()) == null || !targetScript.IsEmpty()))
		{
			UI_Battle_Notification.notification.AddNotification("You need to target an empty tile.", Color.red);
			return (false);
		}
		if (!HasStamina())
		{
			UI_Battle_Notification.notification.AddNotification(owner.name + " doesn't have enough stamina.", Color.red);
			return (false);
		}
		if (!InRange(target))
		{
			UI_Battle_Notification.notification.AddNotification(target.name + " is not in range.", Color.red);
			return (false);
		}
		return (true);
	}

	public override void Action(GameObject target)
	{
		print ("target : " + target.name);
		spell.Cast(owner, target);
	}

	public override void Action_End(bool succes)
	{
		owner.GetActionSystem().EndAction();
		SetColor (false, Tile.EColor.COLOR_TARGET, range);
		//UI_Battle_Notification.notification.Clear();
		bReady = false;
		return;
	}

	public void InitSpell(SpellCast _spell)
	{
		spell = _spell;
		range = spell.range;
		effectZone = spell.effectZone;
		bNeedTarget = spell.bNeedTarget;
		bNeedEmptyTile = spell.bNeedEmptyTile;

		SetColor(true, Tile.EColor.COLOR_TARGET, range);
		UI_Manager.UIManager.UI_Close("UI_Battle_Spell");

		bReady = true;
	}
}
