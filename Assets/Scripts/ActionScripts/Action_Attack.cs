using UnityEngine;
using System.Collections;

public class Action_Attack : Action_Base
{
	private Character	target;

	public int			diceMin;
	public int			diceMax;

	private float		touchProbability;
	private float 		damageEstimation;

	private int			atk_touchScore;
	private int			atk_damage;

	private int			def_damage;
	private int			def_touchScore;

	public Character	GetTarget() { return (target); }
	public float 		GetTouchProbality() { return (touchProbability); }
	public float		GetDamageEstimation() { return (damageEstimation); }

	public int			GetAtkTouchScore() { return (atk_touchScore) ; }
	public int			GetAtkDamage()		{ return (atk_damage) ; }

	public int			GetDefTouchScore() { return (def_touchScore) ; }
	public int			GetDefDamage()	{ return (def_damage) ; }

	public override void Action_Start()
	{
		if (owner.GetActionSystem().action != null)
			owner.GetActionSystem().action.Action_Cancel();
		owner.GetActionSystem().action = this;

		SetColor(true, Tile.EColor.COLOR_TARGET, range);
        MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_NONE;

		touchProbability = 0;
		damageEstimation = 0;
		atk_touchScore = 0;
		atk_damage = 0;
		def_touchScore = 0;
		def_damage = 0;

		bReady = true;
		UI_Battle_Notification.notification.AddNotification("Choose a target", Color.red);
	}
	
	public override void Action_Cancel()
	{
		owner.GetActionSystem().action = null;
		SetColor(false, Tile.EColor.COLOR_TARGET, range);
		UI_Battle_Notification.notification.Clear();
		UI_Manager.UIManager.UI_Close("UI_Battle_Analyser");
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_ONGUI;
		bReady = false;
	}

	public override bool Action_Try(GameObject target)
	{
		Character targetScript;

		if ((targetScript = target.GetComponent<Character>()) == null)
		{
			return (false);
		}
		if (targetScript.IsDead())
		{
			UI_Battle_Notification.notification.AddNotification("You can't target a dead person.", Color.red);
			return (false);
		}
		if (targetScript == owner)
		{
			UI_Battle_Notification.notification.AddNotification("You can't target yourself.", Color.red);
			return (false);
		}
		if (IsOnSameTeam(targetScript))
		{
			UI_Battle_Notification.notification.AddNotification(target.name + " is on the same team.", Color.red);
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
	
	public override void Action(GameObject _target)
	{
		target = _target.GetComponent<Character>();
		CalculateTouchProbabilities(target);
		CalculateDamageEstimation(target);
		MouseController.mouse.state = MouseController.EMouseState.MOUSESTATE_ONGUI;
		UI_Manager.UIManager.UI_Open("UI_Battle_Analyser");
	}

	public override void Action_End(bool success)
	{
		UI_Battle_Summary uiBattleSummary;

		print ("Action End with " + (success ? "success" : "failure"));
		UI_Manager.UIManager.UI_Open("UI_Battle_Summary");
		uiBattleSummary = (UI_Battle_Summary) UI_Manager.UIManager.GetUI("UI_Battle_Summary");
		uiBattleSummary.SetAttack(this);

		UI_Manager.UIManager.UI_Close("UI_Battle_Analyser");
		owner.GetActionSystem().EndAction();
		SetColor (false, Tile.EColor.COLOR_TARGET, range);
		UI_Battle_Notification.notification.Clear();
		bReady = false;
		return;
	}

	public void Attack_Start()
	{
		ActionCost();
		Attack_Touch(target);
		if (atk_touchScore <= 0)
			Action_End(false);
		Attack_Protection(target);
		Attack_Damage(target);
	}

	void Attack_Touch(Character target)
	{
		print ("Attack_Touch");
		atk_touchScore = owner.Attack() + Random.Range(diceMin, diceMax);
		def_touchScore = target.Attack() + Random.Range(diceMin, diceMax);
		print ("attacker_score = " + atk_touchScore);
		print ("defender_score = " + def_touchScore);
		atk_touchScore =  atk_touchScore - def_touchScore;
		print ("bonus_protection = " + atk_touchScore);
	}

	void Attack_Protection(Character target)
	{
		print ("Attack_Protection");
		atk_damage = owner.Attack() + atk_touchScore + Random.Range(diceMin, diceMax);
		def_damage = target.Defense() + Random.Range(diceMin, diceMax);
		print ("atk_damage = " + atk_damage);
		print ("def_damage = " + def_damage);
		atk_damage =  atk_damage - def_damage;
		print ("damage = " + atk_damage);
		if (atk_damage <= 0)
			atk_damage = 1;
	}

	void Attack_Damage(Character target)
	{
		target.GetHealthSystem().TakeHit(atk_damage);
		Action_End(true);
	}

	float CalculateTouchProbabilities(Character target)
	{
		touchProbability = 0;
		for (int i = 1; i < (Mathf.Abs(diceMax - (owner.Attack() - target.Attack()))); i++)
			touchProbability += 1 * i;
		print ("victory : " + touchProbability);
		print ("diff : " + Mathf.Abs(owner.Attack() - target.Attack()));
		print ("max : " + (diceMax * diceMax));
		touchProbability = (((diceMax * diceMax) - Mathf.Abs(owner.Attack() - target.Attack())) * 100) / (diceMax * diceMax);
		print ("touch : " + touchProbability);
		return (touchProbability);
	}



	float CalculateDamageEstimation(Character target)
	{
		damageEstimation = owner.Attack() - target.Defense();
		return (damageEstimation);
	}


}
